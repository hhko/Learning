```
- pipeline.id: 7700-listen-beats
  pipeline.workers: 4
  queue.type: persisted
  queue.max_bytes: 1gb
  path.config: "/usr/share/logstash/pipeline/7700-listen-beats.conf"

- pipeline.id: 7701-listen-logs
  pipeline.workers: 4
  queue.type: persisted
  queue.max_bytes: 1gb
  path.config: "/usr/share/logstash/pipeline/7701-listen-logs.conf"

- pipeline.id: alive
  pipeline.workers: 1
  path.config: "/usr/share/logstash/pipeline/alive.conf"
```
```
input {
  http  {
    port => 7701
  }
}

filter {
  # mutate {
  #   add_field => { "[beat][full_name]" => "%{[@metadata][beat]}-%{[beat][version]}-%{[host][os][platform]}" }
  #   add_field => { "[beat][name]" => "%{[@metadata][beat]}" }
  #   lowercase => [ "[tags]" ]
  # }

  # if ([host][ip]) {
  #  ruby {
  #     add_field => { "[host][ipv4]" => "" }
  #    code => "
  #       arr = event.get('[host][ip]')
  #       arr2 = arr.select{ |a| a.to_s.include? '.' }
  #       strIPv4s = arr2.join(', ')
  #       event.set('[host][ipv4]', strIPv4s)
  #     "
  #   }
  # }
}

output {
  # if ("" in [mirero][kafka_topic]) {
  #   kafka {
  #     bootstrap_servers => "${BLUECATS_KAFKA_HOST}"
  #     max_request_size => 15728640
  #     codec => json
  #     topic_id => "%{[mirero][kafka_topic]}"
  #   }
  # }

  stdout { }

  kafka {
    bootstrap_servers => "${BLUECATS_KAFKA_HOST}"
    max_request_size => 15728640
    codec => json
    topic_id => "mirero.logs"
  }
}
```
---
```
- pipeline.id: kafka-metricbeat
  path.config: "/usr/share/logstash/pipeline/kafka-metricbeat.conf"
  pipeline.workers: 4

- pipeline.id: kafka-logs
  path.config: "/usr/share/logstash/pipeline/kafka-logs.conf"
  pipeline.workers: 4
```

```
input {
  kafka {
    client_id => "logsbeat"
    auto_offset_reset => "earliest"
    bootstrap_servers => "kafka:9092"
    max_partition_fetch_bytes => "15728640"
    topics => ["mirero.logs"]
    codec => json
    decorate_events => true
    max_poll_records => "200"
  }
}

filter{
  ruby {
    code => "event.set('timestamp_collect', Time.now());"
  }
  mutate {
    convert => { "timestamp_collect" => "string" }
  }

  date {
    match => [ "timestamp_collect", "ISO8601" ]
    target => "@timestamp_collect"
    remove_field => [ "timestamp_collect" ]
  }
}

output{
  elasticsearch {
    hosts => [ "elasticsearch:9200" ]
    index => "%{[@metadata][kafka][topic]}-%{+YYYY.MM.dd}"
    ilm_enabled => false
    user => "admin"
    password => "admin"
    ssl => false
    ssl_certificate_verification => false
  }
}
```
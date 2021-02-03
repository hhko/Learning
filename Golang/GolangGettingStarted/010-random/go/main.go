package main

import (
	"fmt"
	"math/rand"
	"time"
)

func main() {
	seconds := time.Now().Unix()
	rand.Seed(seconds)           // 시드 값이 변경되어야만 매번 다른 값이 생성된다.
	target := rand.Intn(100) + 1 // 1 ~ 100 난수 발생

	fmt.Println(target)
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Ch2.CreatingFixture
{
    public class EmailMessage
    {
        // AutoFixture가 할당할 수 없다(private set 접근자다, 생성자 초기화도 없다).
        private string _somePrivateField;
        private string SomePrivateProperty { get; set; }

        // AutoFixture가 할당할 수 있다(public set 접근자다).
        public string SomePublicField;
        public string Subject { get; set; }
        
        // Enum 타입
        public EmailMessageType MessageType { get; set; }

        // Guid 타입
        public Guid Id { get; set; }

        // 생성자
        public string ToAddress { get; set; }
        public bool IsImportant { get; set; }

        // AutoFixture가 접근할 수 없다
        public string MessageBody { get; private set; }     

        // 매개변수가 있는 생성자 
        public EmailMessage(string toAddress, string messageBody, bool isImportant)
        {
            ToAddress = toAddress;
            IsImportant = isImportant;

            // 생성자 매개변수로 AutoFixture가 접근한다. 
            // 접두사는 매개변수 이름이 된다.
            // 예. MessageBody "messageBodyb0238ae0-fa72-418c-be95-b6428048813e", string
            MessageBody = messageBody;  
            
        }
    }
}

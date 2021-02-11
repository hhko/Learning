using System;

namespace App_01_FluentBlobTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
            FluentBlobTransfer
                .Connect("xyz")
                .OnBlob("xyz")
                .Download("xyz")
                .ToFile("xyz");

            //FluentBlobTransfer
            //    .Connect("storageAccountConnectionString")
            //    .OnBlob("blobName")
            //    .Download("fileName")
            //    .ToFile(@"D:\Azure\Downloads\");
        }
    }
}

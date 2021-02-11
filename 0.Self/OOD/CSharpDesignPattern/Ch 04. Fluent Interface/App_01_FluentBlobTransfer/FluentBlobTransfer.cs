using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace App_01_FluentBlobTransfer
{
    public interface IAzureBlob
    {
        IAzureAction OnBlob(string blobBlockPath);
    }

    public interface IAzureAction
    {
        IAzureWrite Download(string fileName);
        IAzureRead Upload(string fileName);
    }

    public interface IAzureWrite
    {
        void ToFile(string filePath);
        void ToStream(Stream stream);
    }

    public interface IAzureRead
    {
        void FromFile(string filePath);
        void FromStream(Stream stream);
    }

    public class AzureBlobNull : IAzureBlob
    {
        public IAzureAction OnBlob(string blobBlockPath)
        {
            return new AzureActionNull();
        }
    }

    public class AzureActionNull : IAzureAction
    {
        public IAzureWrite Download(string fileName)
        {
            return new AzureWriteNull();
        }

        public IAzureRead Upload(string fileName)
        {
            return new AzureReadNull();
        }
    }

    public class AzureWriteNull : IAzureWrite
    {
        public void ToFile(string filePath)
        {

        }

        public void ToStream(Stream stream)
        {

        }
    }

    public class AzureReadNull : IAzureRead
    {
        public void FromFile(string filePath)
        {

        }

        public void FromStream(Stream stream)
        {

        }
    }

    public sealed class FluentBlobTransfer : IAzureBlob, IAzureAction, IAzureWrite, IAzureRead
    {
        private readonly string connectionString;
        private string blobBlockPath;
        private string fileName;

        private FluentBlobTransfer(string connectionString) => this.connectionString = connectionString;

        public static IAzureBlob Connect(string connectionString) => new FluentBlobTransfer(connectionString);

        public IAzureAction OnBlob(string blobBlockPath)
        {
            this.blobBlockPath = blobBlockPath;

            return this;
        }

        public IAzureWrite Download(string fileName)
        {
            this.fileName = fileName;

            return this;
        }

        public IAzureRead Upload(string fileName)
        {
            this.fileName = fileName;

            return this;
        }

        public void ToFile(string filePath)
        {
            // Code to download from Azure Blob Storage to file
        }

        public void ToStream(Stream stream)
        {
            // Code to download from Azure Blob Storage to stream
        }

        public void FromFile(string filePath)
        {
            // Code to upload from file to Azure Blob Storage
        }

        public void FromStream(Stream stream)
        {
            // Code to upload from stream to Azure Blob Storage
        }
    }
}

﻿using System;
using System.IO;
using System.Runtime.Serialization;

namespace DuplicateFinder.IO
{
    [Serializable]
    public class DirectoryException : Exception
    {
        public DirectoryException(DirectoryInfo directory, Exception ex) : base(ex.Message, ex)
        {
            Directory = directory;
        }

        protected DirectoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Directory = (DirectoryInfo)info.GetValue(nameof(Directory), typeof(DirectoryInfo));
        }

        public DirectoryInfo Directory { get; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(Directory), Directory);

            base.GetObjectData(info, context);
        }
    }
}

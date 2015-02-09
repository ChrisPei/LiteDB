﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;

namespace LiteDB.Shell.Commands
{
    internal class FileUpdate : BaseFileStorage, ILiteCommand
    {
        public bool IsCommand(StringScanner s)
        {
            return this.IsFileCommand(s, "update");
        }

        public BsonValue Execute(LiteDatabase db, StringScanner s)
        {
            var id = this.ReadId(s);
            var metadata = new JsonReader().ReadValue(s).AsObject;

            return db.FileStorage.SetMetadata(id, metadata);
        }
    }
}

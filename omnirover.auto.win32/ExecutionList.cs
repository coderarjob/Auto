using System;
using System.Collections.Generic;
using System.IO;

namespace omnirover.auto
{
    public class ExecutionList:List<BaseOperation>
    {
        private const Byte CONTROL_IS_NULL = 0;
        private const Byte CONTROL_IS_NOT_NULL = 1;
        private const Int32 ARGUMENT_IS_NULL = 0;

        public void Save(string filename)
        {
            BinaryWriter wr = new BinaryWriter(new FileStream(filename, FileMode.Create));
            wr.Write((Int32)this.Count);
            foreach (BaseOperation item in this)
            {
                if (item.Control == null)
                    wr.Write(CONTROL_IS_NULL);
                else
                {
                    wr.Write(CONTROL_IS_NOT_NULL);

                    wr.Write((Int32)item.Control.Index);
                    wr.Write((Int32)item.Control.ControlID);
                    wr.Write(item.Control.WindowTitle);
                }

                wr.Write(item.Name);

                if (item.Arguments == null)
                    wr.Write((Int32)ARGUMENT_IS_NULL);
                else
                {
                    wr.Write((Int32)item.Arguments.Count);
                    foreach (string theArg in item.Arguments)
                        wr.Write(theArg);
                }
            }

            wr.Flush();
            wr.Close();
        }

        public static ExecutionList OpenFile(string filename)
        {
            BinaryReader rr = new BinaryReader(new FileStream(filename, FileMode.Open));
            ExecutionList OperationsFromFile = new ExecutionList();
            int count = rr.ReadInt32();
            while(count-- > 0)
            {
                int argCount; 
                List<String> argList = new List<string>();

                Boolean isControlNull = (rr.ReadByte() == CONTROL_IS_NULL);
                ControlIdentity control = null;
                if (!isControlNull)
                {
                    Int32 Index = rr.ReadInt32();
                    Int32 id = rr.ReadInt32();
                    string WindowTitle = rr.ReadString();
                    control = new ControlIdentity(WindowTitle, Index, id);
                }

                string operationName = rr.ReadString();
                argCount = rr.ReadInt32();

                while(argCount-- > 0)
                    argList.Add(rr.ReadString());

                OperationsFromFile.Add(OperationFactory.CreateOperation(operationName,control,argList.ToArray()));

            }
            rr.Close();

            return OperationsFromFile;
        }
    }
}

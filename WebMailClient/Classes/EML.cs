using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CDO;
using ADODB;
using System.Collections;

namespace WebMailClient
{
    class EML
    {
        private ADODB.Stream stm = null;
        private CDO.Message msg = null;

        public string From
        {
            get
            {
                return msg.From;
            }
        }

        public string Subject
        {
            get
            {
                return msg.Subject;
            }
        }

        public string TimeStamp
        {
            get
            {
                return msg.ReceivedTime.ToString();
            }
        }

        public int Size
        {
            get
            {
                return stm.Size;
            }
        }

        public string CC
        {
            get
            {
                return msg.CC;
            }
        }

        public string BCC
        {
            get
            {
                return msg.BCC;
            }
        }

        public string HTMLBody
        {
            get
            {
                return msg.HTMLBody;
            }
        }

        public string TextBody
        {
            get
            {
                return msg.TextBody;
            }
        }

        public int AttachCount
        {
            get
            {
                return msg.Attachments.Count;
            }
        }

        public EML()
        {
            msg = new CDO.Message();
            stm = new ADODB.Stream();
            stm.Open(System.Reflection.Missing.Value,
                     ADODB.ConnectModeEnum.adModeUnknown,
                     ADODB.StreamOpenOptionsEnum.adOpenStreamUnspecified,
                     "", "");
            stm.Type = ADODB.StreamTypeEnum.adTypeBinary;
        }

        public void Close()
        {
            stm.Close();
        }

        public void ParseEML(string file)
        {
            stm.LoadFromFile(file);
            msg.DataSource.OpenObject(stm, "_stream");
        }

        public string GetAttachmentName(int index)
        {
            if (index >= msg.Attachments.Count || index < 0)
                return "";
            IEnumerator enumerator = msg.Attachments.GetEnumerator();
            int i = -1;
            while (i < index)
            {
                enumerator.MoveNext();
                i++;
            }
            IBodyPart attachment = (IBodyPart)enumerator.Current;
            return attachment.FileName;
        }

        public void SaveAttachment(int index, string filename)
        {
            if (index >= msg.Attachments.Count || index < 0)
                return;
            IEnumerator enumerator = msg.Attachments.GetEnumerator();
            int i = -1;
            while (i < index)
            {
                enumerator.MoveNext();
                i++;
            }
            IBodyPart attachment = (IBodyPart)enumerator.Current;
            attachment.SaveToFile(filename);
        }
    }
}

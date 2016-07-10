using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
// using System.Windows.Forms;

namespace ParadoxLocalisationAssistant
{
    //public class TextboxWriter : TextWriter
    //{
    //    private TextBox textbox;
    //    public TextboxWriter(TextBox textbox)
    //    {
    //        this.textbox = textbox;
    //    }

    //    public override void Write(char value)
    //    {
    //        textbox.AppendText(value.ToString());
    //    }

    //    public override void Write(string value)
    //    {
    //        textbox.AppendText(value);
    //    }

    //    public override Encoding Encoding
    //    {
    //        get { return Encoding.Unicode; }
    //    }
    //}

    public class LogWriter : TextWriter
    {
        private List<TextWriter> writers;
        public LogWriter()
        {
            this.writers = null;
        }
        public LogWriter(IEnumerable<TextWriter> writers)
        {
            this.writers = writers.ToList();
        }
        public LogWriter(params TextWriter[] writers)
        {
            this.writers = writers.ToList();
        }

        public void AddWriter(TextWriter writer)
        {
            if (writers == null)
                writers = new List<TextWriter>() { writer };
            else
                writers.Add(writer);
        }

        public override void Write(char value)
        {
            if (writers == null)
                return;
            foreach (var writer in writers)
                writer.Write(value);
        }

        public override void Write(string value)
        {
            if (writers == null)
                return;
            foreach (var writer in writers)
                writer.Write(value);
        }

        public override void Flush()
        {
            if (writers == null)
                return;
            foreach (var writer in writers)
                writer.Flush();
        }

        public override void Close()
        {
            if (writers == null)
                return;
            foreach (var writer in writers)
                writer.Close();
        }

        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }

        protected override void Dispose(bool disposing)
        {
            if (writers == null)
                return;
            if (disposing)
            {
                foreach (var writer in writers)
                    writer.Close();
            }
        }
    }
}

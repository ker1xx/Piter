using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraPiter
{
    internal class CameraModel
    {
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public string StateNumber { get; set; }
        public string Img { get; set; }
        public CameraModel(DateTime Date, bool Status, string StateNumber, string Img)
        {
            this.Date = Date;
            this.Status = Status;
            this.StateNumber = StateNumber;
            this.Img = Img;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskChecker.Web.Models.Entities;

namespace TaskChecker.Web.Models
{
    public class LabWorkViewModel
    {
        public LabWork LabWork
        {
            get;
            set;
        }

        public LabWorkResult LabWorkResult
        {
            get;
            set;
        }
    }
}
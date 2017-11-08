using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnglishForKid.Models.ViewModels
{
	public class ChartStatisticViewModel
	{
        public string[] Labels { get; set; }

        public int[] Views { get; set; }

        public int[] Lessons { get; set; }

        public int[] Users { get; set; }
    }
}
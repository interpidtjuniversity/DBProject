using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    //该类为ChooseFlight页面返回给Flight页面的返回值的数据类型
    public class FlightSelectReturn
    {
        public int[] SeatArray;
        public string Flight_ID;

        public FlightSelectReturn(int[] sa, string fd)
        {
            SeatArray = sa;
            Flight_ID = fd;
        }
    }
}
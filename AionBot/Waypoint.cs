using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AionBot
{
    public class Waypoint
    {
        public string _id;
        public string _x;
        public string _y;
        public string _z;
        public string _collect;
        public string _fly_to;
        public string _rest;
        public string _rest_for;

        public Waypoint(string id,string x,string y, string z,string collect,string fly_to,string rest,string rest_for)
        {
            this._id = id;
            this._x = x;
            this._y = y;
            this._z = z;
            this._collect = collect;
            this._fly_to = fly_to;
            this._rest = rest;
            this._rest_for = rest_for;
        }
    }
}

using System.ComponentModel;

namespace AionBot.Model
{
    public class WaypointModel
    {
        public string _id { get; set; }
        public string _x { get; set; }
        public string _y { get; set; }
        public string _z { get; set; }
        public string _collect { get; set; }
        public string _fly_to { get; set; }
        public string _rest { get; set; }
        public string _rest_for { get; set; }

        public WaypointModel()
        {

        }

        public WaypointModel(string id,string x,string y, string z,string collect,string fly_to,string rest,string rest_for)
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

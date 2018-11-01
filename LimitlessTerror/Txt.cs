using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimitlessTerror {
    class Txt {
        public const string sign = "▓";

        public string Log;

        public Txt() {
            Log = "";
        }
        public string GetResult() {
            return Log;
        }
        public void Head(string Text, int n, bool key) {
            string result = "";
            for (int i = 0; i < n; i++) {
                result += sign;
            }
            Log += result + Text;
            if (key) {
                Log += "\r\n";
            }
        }
        public void AddDetail(string Text, bool key) {
            Log += Text + " ";
            if (key) {
                Log += "\r\n";
            }
        }
        public void Value_add(string Type, string Value) {
            Log += Type + "(" + Value + ")";
        }

        public void Value_add(string Type, string Value, string From) {
            Log += Type + "(" + Value + ":" + From + ")";
        }

    }
}

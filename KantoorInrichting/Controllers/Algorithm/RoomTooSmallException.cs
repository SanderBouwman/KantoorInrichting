// created by: Robin
// on: 09-12-2015

using System;
using System.Runtime.Serialization;

namespace KantoorInrichting.Controllers.Algorithm {

    [Serializable()]
    public class RoomTooSmallException : Exception {

        public RoomTooSmallException() { }
        public RoomTooSmallException(string message) : base(message) { }
        public RoomTooSmallException(string message, Exception inner) : base(message, inner) { }

        protected RoomTooSmallException(SerializationInfo info, StreamingContext context) { }
    }
}
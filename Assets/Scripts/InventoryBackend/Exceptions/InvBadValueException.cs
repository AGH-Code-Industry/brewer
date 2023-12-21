using System;

namespace InventoryBackend.Exceptions {
    public class InvBadValueException : Exception {
        public InvBadValueException(){}
        public InvBadValueException(string message) : base(message) {}
        public InvBadValueException(string message, Exception inner) : base(message, inner){}
    }
}
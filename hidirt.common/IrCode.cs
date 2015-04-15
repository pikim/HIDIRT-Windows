using System;

namespace HIDIRT
{
    public class IrCode
    {
        private Byte _protocol;
        private UInt16 _address;
        private UInt16 _command;
        private Byte _flags;

        public IrCode()
        {
            this._protocol = 0;
            this._address = 0;
            this._command = 0;
            this._flags = 0;
        }

        public IrCode(Byte protocol, UInt16 address, UInt16 command)
        {
            this._protocol = protocol;
            this._address = address;
            this._command = command;
            this._flags = 0;
        }

        public IrCode(Byte protocol, UInt16 address, UInt16 command, Byte flags)
        {
            this._protocol = protocol;
            this._address = address;
            this._command = command;
            this._flags = flags;
        }
        
        public IrCode(Byte[] buffer)
        {
            this._protocol = buffer[0];
            this._address = BitConverter.ToUInt16(buffer, 1);
            this._command = BitConverter.ToUInt16(buffer, 3);
            this._flags = buffer[5];
        }

//        public IrCode(Byte[] buffer, Int16 offset, Boolean withFlags)
//        {
//            this._protocol = buffer[0+offset];
//            this._address = BitConverter.ToUInt16(buffer, 1+offset);
//            this._command = BitConverter.ToUInt16(buffer, 3+offset);
//            if (withFlags)
//              this._flags = buffer[5+offset];
//        }

        public Byte Protocol
        {
            get { return _protocol; }
            set
            {
              this._protocol = value;
            }
        }

        public UInt16 Address
        {
            get { return _address; }
            set
            {
              this._address = value;
            }
        }

        public UInt16 Command
        {
            get { return _command; }
            set
            {
              this._command = value;
            }
        }

        public Byte Flags
        {
            get { return _flags; }
            set
            {
              this._flags = value;
            }
        }
        
        public Byte[] GetBytes()
        {
            Byte[] data = new Byte[6];
            data[0] = _protocol;
            data[1] = (Byte)_address;
            data[2] = (Byte)(_address >> 8);
            data[3] = (Byte)_command;
            data[4] = (Byte)(_command >> 8);
            data[5] = _flags;
            return data;
        }
    }
}

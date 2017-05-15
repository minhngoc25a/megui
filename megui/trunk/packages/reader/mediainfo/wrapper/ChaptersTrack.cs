// ****************************************************************************
// 
// Copyright (C) 2005-2017 Doom9 & al
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
// 
// ****************************************************************************

using System;

namespace MediaInfoWrapper
{
    ///<summary>Contains properties for a ChaptersTrack </summary>
    public class ChaptersTrack
    {
        private string _Count;
        private string _StreamCount;
        private string _StreamKind;
        private string _StreamKindID;
        private string _StreamOrder;
        private string _Inform;
        private string _ID;
        private string _UniqueID;
        private string _Title;
        private string _Codec;
        private string _CodecString;
        private string _CodecUrl;
        private string _Total;
        private string _Language;
        private string _LanguageString;
        private string _Default;
        private string _DefaultString;
        private string _Forced;
        private string _ForcedString;

        ///<summary> Count of objects available in this stream </summary>
        public string Count
        {
            get
            {
                if (String.IsNullOrEmpty(this._Count))
                    this._Count="";
                return _Count;
            }
            set
            {
                this._Count=value;
            }
        }

        ///<summary> Count of streams of that kind available </summary>
        public string StreamCount
        {
            get
            {
                if (String.IsNullOrEmpty(this._StreamCount))
                    this._StreamCount="";
                return _StreamCount;
            }
            set
            {
                this._StreamCount=value;
            }
        }

        ///<summary> Stream name </summary>
        public string StreamKind
        {
            get
            {
                if (String.IsNullOrEmpty(this._StreamKind))
                    this._StreamKind="";
                return _StreamKind;
            }
            set
            {
                this._StreamKind=value;
            }
        }

        ///<summary> When multiple streams, number of the stream </summary>
        public string StreamKindID
        {
            get
            {
                if (String.IsNullOrEmpty(this._StreamKindID))
                    this._StreamKindID="";
                return _StreamKindID;
            }
            set
            {
                this._StreamKindID=value;
            }
        }

        ///<summary>Stream order in the file, whatever is the kind of stream (base=0)</summary>
        public string StreamOrder
        {
            get
            {
                if (String.IsNullOrEmpty(this._StreamOrder))
                    this._StreamOrder = "";
                return _StreamOrder;
            }
            set
            {
                this._StreamOrder = value;
            }
        }

        ///<summary> Last   Inform   call </summary>
        public string Inform
        {
            get
            {
                if (String.IsNullOrEmpty(this._Inform))
                    this._Inform="";
                return _Inform;
            }
            set
            {
                this._Inform=value;
            }
        }

        ///<summary> A ID for this stream in this file </summary>
        public string ID
        {
            get
            {
                if (String.IsNullOrEmpty(this._ID))
                    this._ID="";
                return _ID;
            }
            set
            {
                this._ID=value;
            }
        }

        ///<summary> A unique ID for this stream, should be copied with stream copy </summary>
        public string UniqueID
        {
            get
            {
                if (String.IsNullOrEmpty(this._UniqueID))
                    this._UniqueID="";
                return _UniqueID;
            }
            set
            {
                this._UniqueID=value;
            }
        }

        ///<summary> Name of the track </summary>
        public string Title
        {
            get
            {
                if (String.IsNullOrEmpty(this._Title))
                    this._Title="";
                return _Title;
            }
            set
            {
                this._Title=value;
            }
        }

        ///<summary> Codec used </summary>
        public string Codec
        {
            get
            {
                if (String.IsNullOrEmpty(this._Codec))
                    this._Codec="";
                return _Codec;
            }
            set
            {
                this._Codec=value;
            }
        }

        ///<summary> Codec used (test) </summary>
        public string CodecString
        {
            get
            {
                if (String.IsNullOrEmpty(this._CodecString))
                    this._CodecString="";
                return _CodecString;
            }
            set
            {
                this._CodecString=value;
            }
        }

        ///<summary> Codec used (test) </summary>
        public string CodecUrl
        {
            get
            {
                if (String.IsNullOrEmpty(this._CodecUrl))
                    this._CodecUrl="";
                return _CodecUrl;
            }
            set
            {
                this._CodecUrl=value;
            }
        }

        ///<summary> Total number of chapters </summary>
        public string Total
        {
            get
            {
                if (String.IsNullOrEmpty(this._Total))
                    this._Total="";
                return _Total;
            }
            set
            {
                this._Total=value;
            }
        }

        ///<summary> Language (2 letters) </summary>
        public string Language
        {
            get
            {
                if (String.IsNullOrEmpty(this._Language))
                    this._Language="";
                return _Language;
            }
            set
            {
                this._Language=value;
            }
        }

        ///<summary> Language (full) </summary>
        public string LanguageString
        {
            get
            {
                if (String.IsNullOrEmpty(this._LanguageString))
                    this._LanguageString="";
                return _LanguageString;
            }
            set
            {
                this._LanguageString=value;
            }
        }

        ///<summary> Default Info </summary>
        public string Default
        {
            get
            {
                if (String.IsNullOrEmpty(this._Default))
                    this._Default = "";
                return _Default;
            }
            set
            {
                this._Default = value;
            }
        }

        ///<summary> Default Info (string format)</summary>
        public string DefaultString
        {
            get
            {
                if (String.IsNullOrEmpty(this._DefaultString))
                    this._DefaultString = "";
                return _DefaultString;
            }
            set
            {
                this._DefaultString = value;
            }
        }

        ///<summary> Forced Info </summary>
        public string Forced
        {
            get
            {
                if (String.IsNullOrEmpty(this._Forced))
                    this._Forced = "";
                return _Forced;
            }
            set
            {
                this._Forced = value;
            }
        }

        ///<summary> Forced Info (string format)</summary>
        public string ForcedString
        {
            get
            {
                if (String.IsNullOrEmpty(this._ForcedString))
                    this._ForcedString = "";
                return _ForcedString;
            }
            set
            {
                this._ForcedString = value;
            }
        }
    }
}
// ****************************************************************************
// 
// Copyright (C) 2005-2009  Doom9 & al
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
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

using MeGUI.core.util;

namespace MeGUI
{
    public class dgmFileFactory : IMediaFileFactory
    {

        #region IMediaFileFactory Members

        public IMediaFile Open(string file)
        {
            return new dgmFile(file);
        }

        public int HandleLevel(string file)
        {
            if (file.ToLower().EndsWith(".dgm"))
                return 11;
            return -1;
        }

        #endregion

        #region IIDable Members

        public string ID
        {
            get { return "dgm"; }
        }

        #endregion
    }

    /// <summary>
    /// Summary description for dgmReader.
    /// </summary>
    public class dgmFile : IMediaFile
    {
        private AvsFile reader;
        private string fileName;
        private MediaFileInfo info;

        /// <summary>
        /// initializes the dgm reader
        /// </summary>
        /// <param name="fileName">the DGMPGIndex project file that this reader will process</param>
        public dgmFile(string fileName)
        {
            this.fileName = fileName;
            int c;
            string dgdecodenv = ScriptServer.DGDecodeNVdllPath(out c);
            switch (c)
            {
                case 1: reader = AvsFile.ParseScript("DGSource(\"" + this.fileName + "\")"); break;
                case 2: reader = AvsFile.ParseScript("LoadPlugin(\"" + dgdecodenv + "\")\r\nDGSource(\"" + this.fileName + "\")"); break;
            }
            this.readFileProperties();
        }

        /// <summary>
        /// reads the dgm file, which is essentially a text file
        /// </summary>
        private void readFileProperties()
        {
            info = reader.Info.Clone();
            Dar dar = new Dar(reader.Info.Width, reader.Info.Height);

            info.DAR = dar;
        }
        #region properties
        public MediaFileInfo Info
        {
            get { return info; }
        }
        #endregion

        #region IMediaFile Members

        public bool CanReadVideo
        {
            get { return reader.CanReadVideo; }
        }

        public bool CanReadAudio
        {
            get { return false; }
        }

        public IVideoReader GetVideoReader()
        {
            return reader.GetVideoReader();
        }

        public IAudioReader GetAudioReader(int track)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            reader.Dispose();
        }

        #endregion
    }
}

// ****************************************************************************
//
// Copyright (C) 2005-2012 Doom9 & al
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
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using MeGUI.core.util;

namespace MeGUI
{
    class PgcDemux : CommandlineJobProcessor<PgcDemuxJob>
    {
        public static readonly JobProcessorFactory Factory = new JobProcessorFactory(new ProcessorFactory(init), "PgcDemux");

        private static IJobProcessor init(MainForm mf, Job j)
        {
            if (j is PgcDemuxJob) 
                return new PgcDemux(mf.Settings.PgcDemuxPath);
            return null;
        }

        public PgcDemux(string executablePath)
        {
            this.executable = executablePath;
        }

        protected override void checkJobIO()
        {
            try
            {
                if (!String.IsNullOrEmpty(job.OutputPath))
                    FileUtil.ensureDirectoryExists(job.OutputPath);
                su.Status = "Preparing VOB...";
            }
            finally
            {
                base.checkJobIO();
            }
        }

        protected override bool checkExitCode
        {
            get { return true; }
        }

        protected override string Commandline
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                // Input File
                sb.Append("-pgc " + job.PGCNumber + " -noaud -nosub -customvob n,v,a,s,l \"" + job.Input + "\" \"" + job.OutputPath + "\"");
                return sb.ToString();
            }
        }
    }
}

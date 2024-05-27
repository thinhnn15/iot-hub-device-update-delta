/**
 * @file POSIXustarTarArchive.cs
 *
 * @copyright Copyright (c) Microsoft Corporation.
 * Licensed under the MIT License.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ArchiveUtility;

// The format for tar used this link: https://www.systutorials.com/docs/linux/man/5-tar/

namespace TarArchives
{
    public class POSIXustarTarArchive : TarArchiveBase
    {
        public POSIXustarTarArchive(ArchiveLoaderContext context) : base(context)
        {
        }
        public override string ArchiveSubtype { get { return "ustar"; } }
        protected override void ReadHeader(BinaryReader reader, UInt64 offset, out ArchiveItem chunk, out string payloadName, out UInt64 payloadLength)
        {
            chunk = null;
            payloadName = null;
            payloadLength = 0;
        }
    }
}
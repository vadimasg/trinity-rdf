﻿/*
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE.

Copyright (c) Semiodesk GmbH 2015

Authors:
Moritz Eberl <moritz@semiodesk.com>
Sebastian Faubel <sebastian@semiodesk.com>
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace Semiodesk.Trinity.OntologyGenerator
{
    [XmlRoot("GeneratorConfiguration")]
    public class Configuration
    {

        [XmlElement]
        public string Namespace { get; set; }


        [XmlElement(ElementName = "Ontology")]
        public List<Ontology> OntologyCollection { get; set; }

        public Configuration()
        {
            OntologyCollection = new List<Ontology>();
        }
    }

    public abstract class Source
    {

    }

    public class WebSource : Source
    {

        [XmlIgnore]
        public UriRef FileUrl
        {
            get
            {
                return new UriRef(fileUrl);
            }
            set
            {
                fileUrl = value.OriginalString;
            }
        }

        [XmlElement(ElementName = "FileUrl")]
        public string fileUrl
        {
            get;
            set;
        }
    }

    public class FileSource : Source
    {
        [XmlElement]
        public string Path
        {
            get;
            set;
        }
    }


    public class Ontology
    {

        [XmlElement("Prefix")]
        public string Prefix { get; set; }

        [XmlElement("WebSource", Type = typeof(WebSource))]
        [XmlElement("FileSource", Type = typeof(FileSource))]
        public Source Source { get; set; }

        [XmlIgnore]
        public UriRef Uri
        {
            get
            {
                if (string.IsNullOrEmpty(uriString))
                    return null;
                return new UriRef(uriString);
            }
            set
            {
                uriString = value.OriginalString;
            }
        }

        [XmlElement(ElementName = "Uri")]
        public string uriString { get; set; }

        [XmlElement("MetadataWebSource", Type = typeof(WebSource))]
        [XmlElement("MetadataFileSource", Type = typeof(FileSource))]
        public Source MetadataSource { get; set; }


        [XmlIgnore]
        public UriRef MetadataUri
        {
            get
            {
                if (string.IsNullOrEmpty(metadataUriString))
                    return null;
                return new UriRef(metadataUriString);
            }
            set
            {
                metadataUriString = value.OriginalString;
            }
        }

        [XmlElement(ElementName = "MetadataUri")]
        public string metadataUriString { get; set; }

        public override string ToString()
        {
            if (Uri != null)
                return Uri.OriginalString;
            else
                return "Empty Ontology";
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
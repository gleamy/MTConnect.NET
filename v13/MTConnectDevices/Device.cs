﻿// Copyright (c) 2016 Feenux LLC, All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System.Collections.Generic;
using System.Xml.Serialization;

namespace MTConnect.v13.MTConnectDevices
{
    /// <summary>
    /// The primary container element of each device. 
    /// Device is contained within the top level Devices container. 
    /// There MAY be multiple Device elements in an XML document.
    /// </summary>
    [XmlRoot("Device")]
    public class Device
    {

        #region "Required"

        /// <summary>
        /// The unique identifier for this Device in the document.
        /// An id MUST be unique across all the id attributes in the document.
        /// An XML ID-type.
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// The name of the Device.
        /// THis name should be unique within the XML document to allow for easier data integration.
        /// An NMTOKEN XML type.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// A unique identifier that will only refer ot this Device.
        /// For example, this may be the manufacturer's code and the serial number.
        /// The uuid shoudl be alphanumeric and not exceeding 255 characters.
        /// An NMTOKEN XML type.
        /// </summary>
        [XmlAttribute("uuid")]
        public string Uuid { get; set; }

        #endregion

        #region "Optional"

        /// <summary>
        /// DEPRECATED IN REL. 1.1
        /// </summary>
        [XmlAttribute("iso841Class")]
        public string Iso841Class { get; set; }

        /// <summary>
        /// The name the device manufacturer assigned to this Device.
        /// If the native name is not provided, it MUST be the name.
        /// </summary>
        [XmlAttribute("nativeName")]
        public string NativeName { get; set; }

        /// <summary>
        /// The interval in milliseconds between the completion of the reading of one sample of data from a device until the beginning of the next sampling of that data.
        /// This is the number of milliseconds between data captures.
        /// If the sample interval is smaller than one millisecond, the number can be represented as a floating point number.
        /// For example, an interval of 100 microseconds would be 0.1.
        /// </summary>
        [XmlAttribute("sampleInterval")]
        public string SampleInterval { get; set; }

        /// <summary>
        /// DEPRECATED IN REL. 1.2 (REPLACED BY SampleInterval)
        /// </summary>
        [XmlAttribute("sampleRate")]
        public string SampleRate { get; set; }

        #endregion

        #region "Sub-Elements"

        /// <summary>
        /// An XML element that can contain any descriptive content.
        /// This can contain configuration information and manufacturer specific details.
        /// </summary>
        [XmlElement("Description")]
        public Description Description { get; set; }

        /// <summary>
        /// A container for Component XML Elements associated with this Device.
        /// </summary>
        [XmlArray("Components")]
        [XmlArrayItem("Axes", typeof(Components.Axes.AxesComponent))]
        [XmlArrayItem("Controller", typeof(Components.Controller.ControllerComponent))]
        [XmlArrayItem("Door", typeof(Components.Door.DoorComponent))]
        [XmlArrayItem("Interfaces", typeof(Components.Interfaces.InterfacesComponent))]
        [XmlArrayItem("Systems", typeof(Components.Systems.SystemsComponent))]
        public List<IComponent> Components { get; set; }

        /// <summary>
        /// A container for the Data XML Elements provided by this Device.
        /// The data items define the measured values to be reported by this Device.
        /// </summary>
        [XmlArray("DataItems")]
        public List<DataItem> DataItems { get; set; }

        #endregion

        private static List<DataItem> GetDataItems(IComponent component)
        {
            var l = new List<DataItem>();

            // Add Root DataItems
            if (component.DataItems != null) l.AddRange(component.DataItems);
            
            

            return l;
        }

    }
}
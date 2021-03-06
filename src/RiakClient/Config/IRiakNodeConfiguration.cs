// <copyright file="IRiakNodeConfiguration.cs" company="Basho Technologies, Inc.">
// Copyright 2011 - OJ Reeves & Jeremiah Peschka
// Copyright 2014 - Basho Technologies, Inc.
//
// This file is provided to you under the Apache License,
// Version 2.0 (the "License"); you may not use this file
// except in compliance with the License.  You may obtain
// a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.
// </copyright>

namespace RiakClient.Config
{
    /// <summary>
    /// Represents a configuration for a Riak Node.
    /// </summary>
    public interface IRiakNodeConfiguration
    {
        /// <summary>
        /// The name of the node.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The address of the node.  
        /// Can be an IP address or a resolvable domain name.
        /// </summary>
        string HostAddress { get; set; }

        /// <summary>
        /// The port to use when connecting to the Protocol Buffers API.
        /// </summary>
        int PbcPort { get; set; }

        /// <summary>
        /// The worker pool size to use for this node.
        /// This many workers (and connections) will be available for concurrent use.
        /// </summary>
        int PoolSize { get; set; }

        /// <summary>
        /// The network timeout to use when attempting to read data from Riak.
        /// </summary>
        Timeout NetworkReadTimeout { get; set; }

        /// <summary>
        /// The network timeout to use when attempting to write data to Riak.
        /// </summary>
        Timeout NetworkWriteTimeout { get; set; }

        /// <summary>
        /// The network timeout to use when attempting to connect to Riak.
        /// </summary>
        Timeout NetworkConnectTimeout { get; set; }
    }
}
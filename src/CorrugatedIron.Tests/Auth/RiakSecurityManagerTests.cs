﻿// Copyright (c) 2015 Basho Technologies, Inc.
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

using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using CorrugatedIron.Auth;
using CorrugatedIron.Config;
using CorrugatedIron.Util;
using NUnit.Framework;

namespace CorrugatedIron.Tests.X509
{
    [TestFixture]
    public class RiakSecurityManagerTests
    {
        private IRiakClusterConfiguration clusterConfig;
        private IRiakClusterConfiguration noAuthClusterConfig;

        [TestFixtureSetUp]
        public void RiakSecurityManagerTestFixtureSetUp()
        {
            clusterConfig = RiakClusterConfiguration.LoadFromConfig("riakConfiguration");
            Assert.IsNotNull(clusterConfig);
            noAuthClusterConfig = RiakClusterConfiguration.LoadFromConfig("riakNoAuthConfiguration");
            Assert.IsNotNull(noAuthClusterConfig);
        }

        [Test]
        public void WhenSecurityNotConfiguredInAppConfig_SecurityManagerIndicatesIt()
        {
            var authConfig = noAuthClusterConfig.Authentication;
            var securityManager = new RiakSecurityManager(authConfig);
            Assert.IsFalse(securityManager.IsSecurityEnabled);
        }

        [Test]
        public void WhenSecurityConfiguredInAppConfig_SecurityManagerIndicatesIt()
        {
            var authConfig = clusterConfig.Authentication;
            Assert.IsNotNull(authConfig);
            var securityManager = new RiakSecurityManager(authConfig);
            Assert.IsTrue(securityManager.IsSecurityEnabled);
        }
    }
}

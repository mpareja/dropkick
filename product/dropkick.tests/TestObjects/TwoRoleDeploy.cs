// Copyright 2007-2008 The Apache Software Foundation.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use 
// this file except in compliance with the License. You may obtain a copy of the 
// License at 
// 
//     http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software distributed 
// under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
// CONDITIONS OF ANY KIND, either express or implied. See the License for the 
// specific language governing permissions and limitations under the License.
namespace dropkick.tests.TestObjects
{
    using dropkick.Configuration.Dsl;
    using dropkick.Configuration.Dsl.Files;

    public class TwoRoleDeploy :
        Deployment<TwoRoleDeploy, SampleConfiguration>
    {
        public TwoRoleDeploy()
        {
            Define(settings =>
            {
                DeploymentStepsFor(Web, server =>
                {
                    server.CopyDirectory(o =>
                    {
                        o.Include("..\\FHLBank.Cue.Website");
                        o.Include("..\\settings\\web.test.config"); //.Rename("web.config");
                    }).To("E:\\FHLBApps\\CUE");
                });

                DeploymentStepsFor(Db, server =>
                {
                    server.CopyDirectory(o =>
                    {
                        o.Include("..\\FHLBank.Cue.Website");
                    }).To("E:\\FHLBApps\\CUE");
                });
            });
        }

        public static Role Web { get; set; }
        public static Role Db { get; set; }
    }
}
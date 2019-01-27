namespace DotNet.Project.LaunchSettings.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Xunit;

    public class UnitTest1
    {
        [Fact]
        public void JsonShouldBeDeserializedCorrectly()
        {
            var json = 
                @"{
                    'profiles': {
                        'profile1': {
                            'commandName': 'Project',
                            'launchBrowser': true,
                            'applicationUrl': 'index',
                            'environmentVariables': {
                                'var1': 'value1'
                            }
                        }
                    }
                }";

            var profiles = JsonConvert.DeserializeObject<Profiles>(json);

            var actual = profiles.FirstOrEmpty();

            var expected = new Profile
            {
                CommandName = "Project",
                LaunchBrowser = true,
                ApplicationUrl = "index",
                EnvironmentVariables = new Dictionary<string, string>
                {
                    ["var1"] = "value1"
                }
            };
            
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
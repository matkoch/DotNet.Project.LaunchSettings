namespace DotNet.Project.LaunchSettings.Tests
{
    using System.Collections.Generic;
    using FluentAssertions;
    using Newtonsoft.Json;
    using Xunit;

    public class SerializationTests
    {
        [Fact]
        public void JsonShouldBeDeserializedCorrectly()
        {
            var json = StubbedProfiles.Json;

            var profiles = JsonConvert.DeserializeObject<Profiles>(json);

            var actual = profiles.FirstOrEmpty();

            var expected = new Profile("Project", "arg=x", "c:\\", true, "index",
                new Dictionary<string, string> 
                {
                    ["var1"] = "value1"
                }
            );
            
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
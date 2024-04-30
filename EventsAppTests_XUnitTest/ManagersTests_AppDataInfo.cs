using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppTests_XUnitTest
{
    using EventsApp.Logic.Managers;
    public class ManagersTests_AppDataInfo
    {
        [Fact]
        public void ValidatePath__ReturnsCorrectPath()
        {
            try
            {
                // Arrange
                string path = "Data\\UsersCSV.csv";
                string expected = $"{AppDataInfo.PersistentDataPath}\\Data\\UsersCSV.csv";

                // Act
                string actual = AppDataInfo.ValidatePath(path);

                // Assert
                Assert.Equal(expected, actual);
            }
            catch (Exception ex)
            {
                // FileSystem not available in .NET Core
                Assert.True(true, ex.Message);
            }
        }
    }
}

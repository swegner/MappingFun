using AutoMapper;
using FluentAssertions;
using Ploeh.AutoFixture;
using System.Collections.Generic;
using Xunit;

namespace MappingFun.DataTransferObjects
{
    public class Foo
    {
        public int Primative { get; set; }
        public Bar Bar { get; set; }
        public Baz[] Bazes { get; set; }
    }

    public class Bar
    {
        public bool IsClosingTime { get; set; }
    }

    public class Baz
    {
        public float Value { get; set; }
    }
}

namespace MappingFun.DataModel
{
    public class Foo
    {
        public int? Primative { get; set; }
        public Bar Bar { get; set; }
        public List<Baz> Bazes { get; set; }
    }

    public class Bar
    {
        public bool IsClosingTime { get; set; }
    }

    public class Baz
    {
        public float Value { get; set; }
    }
}

namespace MappingFun.Tests
{
    using DM = MappingFun.DataModel;
    using DTO = MappingFun.DataTransferObjects;

    public class MappingTests
    {
        static MappingTests()
        {
            Mapper
                .CreateMap<DTO.Foo, DM.Foo>()
                .ReverseMap();

            Mapper
                .CreateMap<DTO.Bar, DM.Bar>()
                .ReverseMap();

            Mapper
                .CreateMap<DTO.Baz, DM.Baz>()
                .ReverseMap();
        }

        private Fixture _fixture = new Fixture();

        [Fact]
        public void DataTransferObjectToDataModel()
        {
            // Arrange
            var dto = _fixture.Create<DTO.Foo>();

            // Act
            var dataModel = Mapper.Map<DM.Foo>(dto);

            // Assert
            dto.ShouldBeEquivalentTo(dataModel);
        }

        [Fact]
        public void DataModelToDataTransferObject()
        {
            // Arrange
            var dataModel = _fixture.Create<DM.Foo>();

            // Act
            var dto = Mapper.Map<DTO.Foo>(dataModel);

            // Assert
            dataModel.ShouldBeEquivalentTo(dto);
        }
    }
}

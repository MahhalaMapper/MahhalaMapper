namespace MahhalaMapper.UnitTests.Bug;

public class DeepNestingStackOverflow : MahhalaMapperSpecBase
{
    public class Circular { public Circular Self { get; set; } }

    protected override MapperConfiguration CreateConfiguration() => new(cfg => cfg.CreateMap<Circular, Circular>());

    // Verifies that mapping a deeply nested self-referential object does not
    // crash the process with a StackOverflowException (GHSA-rvv3-g6hj-g44x).
    // MahhalaMapper auto-applies a default MaxDepth of 64 when it detects a
    // self-referential reference-type mapping.
    [Fact]
    public void Mapping_deeply_nested_self_referential_object_should_not_stack_overflow()
    {
        var root = new Circular();
        var current = root;
        for (int i = 0; i < 30_000; i++)
        {
            current.Self = new Circular();
            current = current.Self;
        }

        var result = Mapper.Map<Circular>(root);
        result.ShouldNotBeNull();

        int depth = 0;
        current = result;
        while (current.Self != null)
        {
            depth++;
            current = current.Self;
        }
        depth.ShouldBeLessThanOrEqualTo(64);
    }
}

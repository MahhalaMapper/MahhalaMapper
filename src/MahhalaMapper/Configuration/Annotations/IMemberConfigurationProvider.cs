namespace MahhalaMapper.Configuration;

public interface IMemberConfigurationProvider
{
    void ApplyConfiguration(IMemberConfigurationExpression memberConfigurationExpression);
}
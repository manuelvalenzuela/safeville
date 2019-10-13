namespace SafeVille.Core.UseCases
{
    using Dtos.Out;
    using Exceptions;

    public static class CreateCommunityUseCase
    {
        public static CommunityCreated Create(object o)
        {
            if (o == null)
            {
                throw new AppArgumentException(nameof(o));
            }

            return null;
        }
    }
}
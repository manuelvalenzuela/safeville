namespace SafeVille.Core.UseCases
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Dtos.Out;
    using Exceptions;

    public static class InviteUserToJoinACommunityUseCase
    {
        public static async Task<VehicleRegistered> Invite(object o)
        {
            if (o == null)
            {
                throw new AppArgumentException(nameof(o));
            }

            return null;
        }
    }
}
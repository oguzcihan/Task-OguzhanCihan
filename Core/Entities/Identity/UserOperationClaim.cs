namespace Core.Entities.Identity
{
    public class UserOperationClaim : AbsBaseEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
    }
}

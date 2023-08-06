using Core.Entities.Identity;

namespace Business.Abstracts
{
    public interface IUserService
    {
        /// <summary>
        /// Kullanıcı rollerini döner.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<OperationClaim> GetClaims(User user);

        /// <summary>
        /// Kullanıcı kayıt işlemini yapar.
        /// </summary>
        /// <param name="user"></param>
        void Add(User user);

        /// <summary>
        /// Username'e göre kullanıcıyı döner.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetByUsername(string username);

        /// <summary>
        /// In-Memory için default verileri ekler.
        /// </summary>
        void AddDefaultDataForInMemory();

    }
}

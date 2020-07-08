using Refit;
using StockManagement.Services.Refit.Contracts.Requests;
using StockManagement.Services.Refit.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagement.Services.Refit
{
    public interface IStockApi
    {
        #region "/api/{version}/typesproduit" Gestion des types de produits

        /// <summary>  Récupérer la liste non paginée des types de produits</summary>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit/all")]
        Task<ApiResponse<IEnumerable<TypeProduit>>> GetTypesProduit(string v = "v1");

        /// <summary>  Récupérer la liste  paginée des types de produits</summary>
        /// <param name="pagination">  Les paramètres de pagination</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit")]
        Task<ApiResponse<PaginatedResponse<TypeProduit>>> GetPaginatedTypesProduit(PagingParams pagination, string v = "v1");

        /// <summary>  Créer un type de produit</summary>
        /// <param name="payload"> le type de produit a crée</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Post("/api/{v}/typesproduit")]
        Task<ApiResponse<string>> CreateTypeProduit([Body] CreateTypeProduit payload, string v = "v1");

        /// <summary>  Modifier un type de produit</summary>
        /// <param name="id">L'id du type de produit à modifier</param>
        /// <param name="payload"> le type de produit a modifié</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Post("/api/{v}/typesproduit/{id}")]
        Task UpdateTypeProduit(Guid id, [Body] UpdateTypeProduit payload, string v = "v1");

        /// <summary>  Supprimer un type de produit</summary>
        /// <param name="id">L'id du type de produit à supprimer</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Post("/api/{v}/typesproduit/{id}")]
        Task DeleteTypeProduit(Guid id, string v = "v1");

        #endregion "/api/{version}/typesproduit" Gestion des types de produits

        #region "/api/{version}/users" Gestion des utilisateurs

        /// <summary>  Récupérer la liste non paginée des utilisateurs</summary>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit/all")]
        Task<ApiResponse<IEnumerable<User>>> GetUsers(string v = "v1");

        /// <summary>  Récupérer la liste paginée des utilisateurs</summary>
        /// <param name="pagination">  Les paramètres de pagination</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit")]
        Task<ApiResponse<PaginatedResponse<User>>> GetPaginatedUsers(PagingParams pagination, string v = "v1");

        /// <summary>  Créer un utilisateur</summary>
        /// <param name="payload"> les informations sur l'utilisateur a crée</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Post("/api/{v}/typesproduit")]
        Task<ApiResponse<string>> CreateUser([Body] CreateUser payload, string v = "v1");

        /// <summary>  Modifier un utilisateur</summary>
        /// <param name="id">L'id de l'utilisateur à modifier</param>
        /// <param name="payload"> les informations modifier de l'utilisateur</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Post("/api/{v}/typesproduit/{id}")]
        Task UpdateUser(Guid id, [Body] UpdateUser payload, string v = "v1");

        /// <summary> Modifier le status de l'utilisateur</summary>
        /// <param name="id">L'id de l'utilisateur à modifier</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Post("/api/{v}/typesproduit/{id}")]
        Task ToggleStatusUser(Guid id, string v = "v1");

        #endregion "/api/{version}/users" Gestion des utilisateurs

        #region "/api/{version}/users" Gestion des activités

        /// <summary>  Récupérer la liste non paginée des retraits</summary>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit/all")]
        Task<ApiResponse<IEnumerable<Retrait>>> GetRetraits(string v = "v1");

        /// <summary>  Récupérer la liste paginée des retraits</summary>
        /// <param name="pagination">  Les paramètres de pagination</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit")]
        Task<ApiResponse<PaginatedResponse<Retrait>>> GetPaginatedRetraits(PagingParams pagination, string v = "v1");

        /// <summary> Enregistrer un achat</summary>
        /// <param name="payload"> les informations sur le retrait a enregistré</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Post("/api/{v}/typesproduit")]
        Task<ApiResponse<string>> CreateRetrait([Body] CreateRetrait payload, string v = "v1");

        /// <summary>  Récupérer la liste non paginée des achats</summary>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit/all")]
        Task<ApiResponse<IEnumerable<Achat>>> GetAchats(string v = "v1");

        /// <summary>  Récupérer la liste paginée des achats</summary>
        /// <param name="pagination">  Les paramètres de pagination</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit")]
        Task<ApiResponse<PaginatedResponse<Achat>>> GetPaginatedAchats(PagingParams pagination, string v = "v1");

        /// <summary> Enregistrer un achat</summary>
        /// <param name="payload"> les informations sur l'achat a enregistré</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Post("/api/{v}/typesproduit")]
        Task<ApiResponse<string>> CreateAchat([Body] CreateAchat payload, string v = "v1");

        #endregion "/api/{version}/users" Gestion des activités

        #region "/api/{version}/users" Gestion de l'historique

        /// <summary>  Récupérer la liste non paginée de l'historique des actions</summary>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit/all")]
        Task<ApiResponse<IEnumerable<Historique>>> GetHistoriques(string v = "v1");

        /// <summary>  Récupérer la liste paginée de l'historique des actions</summary>
        /// <param name="pagination">  Les paramètres de pagination</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit")]
        Task<ApiResponse<PaginatedResponse<Historique>>> GetPaginatedHistoriques(PagingParams pagination, string v = "v1");

        #endregion "/api/{version}/users" Gestion de l'historique

        #region "/api/{version}/users" Gestion du stock

        /// <summary>  Récupérer la liste non paginée de l'ensemble des produits dans le stock</summary>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit/all")]
        Task<ApiResponse<IEnumerable<Produit>>> GetProduits(string v = "v1");

        /// <summary>  Récupérer la liste paginée de l'ensemble des produits dans le stock</summary>
        /// <param name="pagination">  Les paramètres de pagination</param>
        /// <param name="v">  La version de l'api</param>
        /// <returns></returns>
        [Get("/api/{v}/typesproduit")]
        Task<ApiResponse<PaginatedResponse<Produit>>> GetPaginatedProduits(PagingParams pagination, string v = "v1");

        #endregion "/api/{version}/users" Gestion du stock
    }
}
﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceOAuth2
{
    /// <summary>
    /// Basic details of a device OAuth instance
    /// </summary>
    public interface IDeviceOAuthInfo
    {
        /// <summary>
        /// Status event raised each time confirmation is checked for.
        /// <see cref="System.Int32"/> argument is the number of seconds until the authorization request times out.
        /// </summary>
        event EventHandler<int> WaitingForConfirmation;

        /// <summary>
        /// Details describing the endpoint of the OAuth2 instance
        /// </summary>
        EndPointInfo EndPoint { get; }

        /// <summary>
        /// The scope(s) being authorized
        /// </summary>
        string Scope { get; }


        /// <summary>
        /// The ClientId of the app requesting authorization
        /// </summary>
        string ClientId { get; }

        /// <summary>
        /// Checks the validity of a token against the auth endpoint.
        /// It does this by making a get request to the token's <see cref="EndPointInfo.ProfileUri"/>.
        /// This is useful for ensuring that the user hasn't revoked authorization for a stored token and that it hasn't expired.
        /// </summary>
        /// <param name="token">The token to check</param>
        /// <returns>True if the user profile is return without error</returns>
        Task<bool> CheckToken(TokenInfo token);

        /// <summary>
        /// Checks the validity of a token against the auth endpoint.
        /// It does this by making a get request to the token's <see cref="EndPointInfo.ProfileUri"/>.
        /// This is useful for ensuring that the user hasn't revoked authorization for a stored token and that it hasn't expired.
        /// </summary>
        /// <param name="token">The token to check</param>
        /// <param name="cancelToken">A cancellation token</param>
        /// <returns>True if the user profile is return without error</returns>
        Task<bool> CheckToken(TokenInfo token, CancellationToken cancelToken);

        /// <summary>
        /// Returns the user's endpoint profile using <see cref="EndPointInfo.ProfileUri"/>.
        /// </summary>
        /// <param name="token">The token</param>
        /// <returns>User's profile</returns>
        Task<dynamic> GetProfile(TokenInfo token);

        /// <summary>
        /// Returns the user's endpoint profile using <see cref="EndPointInfo.ProfileUri"/>.
        /// </summary>
        /// <param name="token">The token</param>
        /// <param name="cancelToken">A cancellation token</param>
        /// <returns>User's profile</returns>
        Task<dynamic> GetProfile(TokenInfo token, CancellationToken cancelToken);
    }
}

﻿namespace RiakClient.Commands
{
    using System;
    using Messages;

    /// <summary>
    /// Base class for Riak commands.
    /// </summary>
    /// <typeparam name="TOptions">The type of the options for this command.</typeparam>
    /// <typeparam name="TResponse">The type of the response data from Riak.</typeparam>
    public abstract class Command<TOptions, TResponse> : IRiakCommand
        where TOptions : CommandOptions
        where TResponse : Response
    {
        protected readonly TOptions CommandOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command{TOptions, TResponse}"/> class.
        /// </summary>
        /// <param name="options">Options for this operation. See <see cref="CommandOptions"/></param>
        public Command(TOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            CommandOptions = options;
        }

        public TOptions Options
        {
            get { return CommandOptions; }
        }

        /// <summary>
        /// A sub-class instance of <see cref="Response"/> representing the response from Riak.
        /// </summary>
        public TResponse Response { get; protected set; }

        public abstract MessageCode ExpectedCode { get; }

        public abstract RpbReq ConstructPbRequest();

        public abstract void OnSuccess(RpbResp rpbResp);

        protected RiakString GetKey(RiakString optskey, RpbResp response)
        {
            RiakString key = optskey;

            IRpbGeneratedKey krsp = response as IRpbGeneratedKey;
            if (krsp != null && krsp.HasKey)
            {
                key = new RiakString(krsp.key);
            }

            return key;
        }
    }
}
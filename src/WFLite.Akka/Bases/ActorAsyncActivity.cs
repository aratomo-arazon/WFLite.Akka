/*
 * ActorAsyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Akka.Actor;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WFLite.Logging.Bases;

namespace WFLite.Akka.Bases
{
    public abstract class ActorAsyncActivity : LoggingAsyncActivity
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorAsyncActivity(ILogger logger, IActorContext context, IActorRef self, IActorRef sender)
            : base(logger)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override Task<bool> run(ILogger logger, CancellationToken cancellationToken)
        {
            return run(logger, _context, _self, _sender, cancellationToken);
        }

        protected abstract Task<bool> run(ILogger logger, IActorContext context, IActorRef self, IActorRef sender, CancellationToken cancellationToken);
    }
}
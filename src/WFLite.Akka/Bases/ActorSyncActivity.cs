/*
 * ActorSyncActivity.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Akka.Actor;
using Microsoft.Extensions.Logging;
using WFLite.Activities;
using WFLite.Logging.Bases;

namespace WFLite.Akka.Bases
{
    public abstract class ActorSyncActivity : SyncActivity
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorSyncActivity(IActorContext context, IActorRef self, IActorRef sender)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override bool run()
        {
            return run(_context, _self, _sender);
        }

        protected abstract bool run(IActorContext context, IActorRef self, IActorRef sender);
    }

    public abstract class ActorSyncActivity<TCategoryName> : LoggingSyncActivity<TCategoryName>
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorSyncActivity(ILogger<TCategoryName> logger, IActorContext context, IActorRef self, IActorRef sender)
            : base(logger)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override bool run(ILogger<TCategoryName> logger)
        {
            return run(logger, _context, _self, _sender);
        }

        protected abstract bool run(ILogger<TCategoryName> logger, IActorContext context, IActorRef self, IActorRef sender);
    }
}
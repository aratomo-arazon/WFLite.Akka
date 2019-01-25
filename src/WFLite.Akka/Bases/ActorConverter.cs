/*
 * ActorConverter.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Akka.Actor;
using Microsoft.Extensions.Logging;
using WFLite.Logging.Bases;

namespace WFLite.Akka.Bases
{
    public abstract class ActorConverter : WFLite.Bases.Converter
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorConverter(IActorContext context, IActorRef self, IActorRef sender)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override object convert(object value)
        {
            return convert(_context, _self, _sender);
        }

        protected abstract bool convert(IActorContext context, IActorRef self, IActorRef sender);
    }

    public abstract class ActorConverter<TCategoryName> : LoggingConverter<TCategoryName>
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorConverter(ILogger<TCategoryName> logger, IActorContext context, IActorRef self, IActorRef sender)
            : base(logger)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override object convert(ILogger<TCategoryName> logger, object value)
        {
            return convert(logger, _context, _self, _sender);
        }

        protected abstract bool convert(ILogger<TCategoryName> logger, IActorContext context, IActorRef self, IActorRef sender);
    }
}

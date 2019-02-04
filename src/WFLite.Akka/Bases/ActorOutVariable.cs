/*
 * ActorOutVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Akka.Actor;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Akka.Bases
{
    public abstract class ActorOutVariable : OutVariable
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorOutVariable(IActorContext context, IActorRef self, IActorRef sender, IConverter converter = null)
            : base(converter)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override object getValue()
        {
            return getValue(_context, _self, _sender);
        }

        protected abstract object getValue(IActorContext context, IActorRef self, IActorRef sender);
    }

    public abstract class ActorOutVariable<TValue> : OutVariable<TValue>
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorOutVariable(IActorContext context, IActorRef self, IActorRef sender, IConverter<TValue> converter = null)
            : base(converter)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override object getValue()
        {
            return getValue(_context, _self, _sender);
        }

        protected abstract object getValue(IActorContext context, IActorRef self, IActorRef sender);
    }
}

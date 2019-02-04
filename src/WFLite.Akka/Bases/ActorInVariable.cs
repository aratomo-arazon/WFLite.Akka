/*
 * ActorInVariable.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Akka.Actor;
using WFLite.Bases;

namespace WFLite.Akka.Bases
{
    public abstract class ActorInVariable : InVariable
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorInVariable(IActorContext context, IActorRef self, IActorRef sender)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override void setValue(object value)
        {
            setValue(_context, _self, _sender, value);
        }

        protected abstract void setValue(IActorContext context, IActorRef self, IActorRef sender, object value);
    }

    public abstract class ActorInVariable<TValue> : InVariable<TValue>
    {
        private readonly IActorContext _context;

        private readonly IActorRef _self;

        private readonly IActorRef _sender;

        public ActorInVariable(IActorContext context, IActorRef self, IActorRef sender)
        {
            _context = context;
            _self = self;
            _sender = sender;
        }

        protected sealed override void setValue(object value)
        {
            setValue(_context, _self, _sender, value);
        }

        protected abstract object getValue(IActorContext context, IActorRef self, IActorRef sender);

        protected abstract void setValue(IActorContext context, IActorRef self, IActorRef sender, object value);
    }
}

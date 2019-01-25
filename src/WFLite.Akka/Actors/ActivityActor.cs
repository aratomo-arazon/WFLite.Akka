/*
 * ActivityActor.cs
 *
 * Copyright (c) 2019 aratomo-arazon
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */
 
using Akka.Actor;
using System;
using WFLite.Interfaces;

namespace WFLite.Akka.Actors
{
    public class ActivityActor : ReceiveActor
    {
        protected void Receive<TMessage, TActivity>()
            where TActivity : IActivity
        {
            Receive<TMessage>(async message =>
            {
                var activity = Activator.CreateInstance(typeof(TActivity), Context, Self, Sender, message) as IActivity;

                await activity.Start();
            });
        }

        protected void Receive<TMessage>(Func<IActorContext, IActorRef, IActorRef, TMessage, IActivity> createFunc)
        {
            Receive<TMessage>(async message =>
            {
                var activity = createFunc(Context, Self, Sender, message);

                await activity.Start();
            });
        }
    }
}

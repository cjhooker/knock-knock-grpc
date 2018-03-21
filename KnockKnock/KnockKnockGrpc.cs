// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: KnockKnock.proto
// </auto-generated>
#pragma warning disable 1591
#region Designer generated code

using System;
using System.Threading;
using System.Threading.Tasks;
using grpc = global::Grpc.Core;

namespace KnockKnock {
  public static partial class KnockKnockService
  {
    static readonly string __ServiceName = "KnockKnock.KnockKnockService";

    static readonly grpc::Marshaller<global::KnockKnock.KnockKnockRequest> __Marshaller_KnockKnockRequest = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KnockKnock.KnockKnockRequest.Parser.ParseFrom);
    static readonly grpc::Marshaller<global::KnockKnock.KnockKnockResponse> __Marshaller_KnockKnockResponse = grpc::Marshallers.Create((arg) => global::Google.Protobuf.MessageExtensions.ToByteArray(arg), global::KnockKnock.KnockKnockResponse.Parser.ParseFrom);

    static readonly grpc::Method<global::KnockKnock.KnockKnockRequest, global::KnockKnock.KnockKnockResponse> __Method_RequestKnockKnock = new grpc::Method<global::KnockKnock.KnockKnockRequest, global::KnockKnock.KnockKnockResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RequestKnockKnock",
        __Marshaller_KnockKnockRequest,
        __Marshaller_KnockKnockResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::KnockKnock.KnockKnockReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of KnockKnockService</summary>
    public abstract partial class KnockKnockServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::KnockKnock.KnockKnockResponse> RequestKnockKnock(global::KnockKnock.KnockKnockRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for KnockKnockService</summary>
    public partial class KnockKnockServiceClient : grpc::ClientBase<KnockKnockServiceClient>
    {
      /// <summary>Creates a new client for KnockKnockService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public KnockKnockServiceClient(grpc::Channel channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for KnockKnockService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public KnockKnockServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected KnockKnockServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected KnockKnockServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::KnockKnock.KnockKnockResponse RequestKnockKnock(global::KnockKnock.KnockKnockRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return RequestKnockKnock(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::KnockKnock.KnockKnockResponse RequestKnockKnock(global::KnockKnock.KnockKnockRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_RequestKnockKnock, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::KnockKnock.KnockKnockResponse> RequestKnockKnockAsync(global::KnockKnock.KnockKnockRequest request, grpc::Metadata headers = null, DateTime? deadline = null, CancellationToken cancellationToken = default(CancellationToken))
      {
        return RequestKnockKnockAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::KnockKnock.KnockKnockResponse> RequestKnockKnockAsync(global::KnockKnock.KnockKnockRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_RequestKnockKnock, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override KnockKnockServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new KnockKnockServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(KnockKnockServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_RequestKnockKnock, serviceImpl.RequestKnockKnock).Build();
    }

  }
}
#endregion
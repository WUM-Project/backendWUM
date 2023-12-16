// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Proto/applicant.proto
// </auto-generated>
#pragma warning disable 0414, 1591, 8981, 0612
#region Designer generated code

using grpc = global::Grpc.Core;

namespace GrpcCatalog {
  public static partial class CatalogGrpc
  {
    static readonly string __ServiceName = "CatalogGrpc";

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcCatalog.RemoveExamRequest> __Marshaller_RemoveExamRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcCatalog.RemoveExamRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcCatalog.RemoveExamResponce> __Marshaller_RemoveExamResponce = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcCatalog.RemoveExamResponce.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcCatalog.GetUserDataRequest> __Marshaller_GetUserDataRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcCatalog.GetUserDataRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcCatalog.GetUserDataResponse> __Marshaller_GetUserDataResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcCatalog.GetUserDataResponse.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcCatalog.UserExamRequest> __Marshaller_UserExamRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcCatalog.UserExamRequest.Parser));
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Marshaller<global::GrpcCatalog.UserExamResponse> __Marshaller_UserExamResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::GrpcCatalog.UserExamResponse.Parser));

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcCatalog.RemoveExamRequest, global::GrpcCatalog.RemoveExamResponce> __Method_RemoveExamFromCatalogData = new grpc::Method<global::GrpcCatalog.RemoveExamRequest, global::GrpcCatalog.RemoveExamResponce>(
        grpc::MethodType.Unary,
        __ServiceName,
        "RemoveExamFromCatalogData",
        __Marshaller_RemoveExamRequest,
        __Marshaller_RemoveExamResponce);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcCatalog.GetUserDataRequest, global::GrpcCatalog.GetUserDataResponse> __Method_GetUseData = new grpc::Method<global::GrpcCatalog.GetUserDataRequest, global::GrpcCatalog.GetUserDataResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "GetUseData",
        __Marshaller_GetUserDataRequest,
        __Marshaller_GetUserDataResponse);

    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    static readonly grpc::Method<global::GrpcCatalog.UserExamRequest, global::GrpcCatalog.UserExamResponse> __Method_CheckIfExamExistsInUsers = new grpc::Method<global::GrpcCatalog.UserExamRequest, global::GrpcCatalog.UserExamResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CheckIfExamExistsInUsers",
        __Marshaller_UserExamRequest,
        __Marshaller_UserExamResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::GrpcCatalog.ApplicantReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of CatalogGrpc</summary>
    [grpc::BindServiceMethod(typeof(CatalogGrpc), "BindService")]
    public abstract partial class CatalogGrpcBase
    {
      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcCatalog.RemoveExamResponce> RemoveExamFromCatalogData(global::GrpcCatalog.RemoveExamRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcCatalog.GetUserDataResponse> GetUseData(global::GrpcCatalog.GetUserDataRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

      [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
      public virtual global::System.Threading.Tasks.Task<global::GrpcCatalog.UserExamResponse> CheckIfExamExistsInUsers(global::GrpcCatalog.UserExamRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static grpc::ServerServiceDefinition BindService(CatalogGrpcBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_RemoveExamFromCatalogData, serviceImpl.RemoveExamFromCatalogData)
          .AddMethod(__Method_GetUseData, serviceImpl.GetUseData)
          .AddMethod(__Method_CheckIfExamExistsInUsers, serviceImpl.CheckIfExamExistsInUsers).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    [global::System.CodeDom.Compiler.GeneratedCode("grpc_csharp_plugin", null)]
    public static void BindService(grpc::ServiceBinderBase serviceBinder, CatalogGrpcBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_RemoveExamFromCatalogData, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcCatalog.RemoveExamRequest, global::GrpcCatalog.RemoveExamResponce>(serviceImpl.RemoveExamFromCatalogData));
      serviceBinder.AddMethod(__Method_GetUseData, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcCatalog.GetUserDataRequest, global::GrpcCatalog.GetUserDataResponse>(serviceImpl.GetUseData));
      serviceBinder.AddMethod(__Method_CheckIfExamExistsInUsers, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::GrpcCatalog.UserExamRequest, global::GrpcCatalog.UserExamResponse>(serviceImpl.CheckIfExamExistsInUsers));
    }

  }
}
#endregion

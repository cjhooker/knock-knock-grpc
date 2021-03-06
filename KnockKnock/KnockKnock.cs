// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: KnockKnock.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace KnockKnock {

  /// <summary>Holder for reflection information generated from KnockKnock.proto</summary>
  public static partial class KnockKnockReflection {

    #region Descriptor
    /// <summary>File descriptor for KnockKnock.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static KnockKnockReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChBLbm9ja0tub2NrLnByb3RvEgpLbm9ja0tub2NrIiEKEUtub2NrS25vY2tS",
            "ZXF1ZXN0EgwKBGxpbmUYASABKAkiNwoSS25vY2tLbm9ja1Jlc3BvbnNlEgwK",
            "BGxpbmUYASABKAkSEwoLaXNQdW5jaExpbmUYAiABKAgyaQoRS25vY2tLbm9j",
            "a1NlcnZpY2USVAoRUmVxdWVzdEtub2NrS25vY2sSHS5Lbm9ja0tub2NrLktu",
            "b2NrS25vY2tSZXF1ZXN0Gh4uS25vY2tLbm9jay5Lbm9ja0tub2NrUmVzcG9u",
            "c2UiAGIGcHJvdG8z"));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::KnockKnock.KnockKnockRequest), global::KnockKnock.KnockKnockRequest.Parser, new[]{ "Line" }, null, null, null),
            new pbr::GeneratedClrTypeInfo(typeof(global::KnockKnock.KnockKnockResponse), global::KnockKnock.KnockKnockResponse.Parser, new[]{ "Line", "IsPunchLine" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  public sealed partial class KnockKnockRequest : pb::IMessage<KnockKnockRequest> {
    private static readonly pb::MessageParser<KnockKnockRequest> _parser = new pb::MessageParser<KnockKnockRequest>(() => new KnockKnockRequest());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<KnockKnockRequest> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::KnockKnock.KnockKnockReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public KnockKnockRequest() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public KnockKnockRequest(KnockKnockRequest other) : this() {
      line_ = other.line_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public KnockKnockRequest Clone() {
      return new KnockKnockRequest(this);
    }

    /// <summary>Field number for the "line" field.</summary>
    public const int LineFieldNumber = 1;
    private string line_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Line {
      get { return line_; }
      set {
        line_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as KnockKnockRequest);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(KnockKnockRequest other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Line != other.Line) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Line.Length != 0) hash ^= Line.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Line.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Line);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Line.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Line);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(KnockKnockRequest other) {
      if (other == null) {
        return;
      }
      if (other.Line.Length != 0) {
        Line = other.Line;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Line = input.ReadString();
            break;
          }
        }
      }
    }

  }

  public sealed partial class KnockKnockResponse : pb::IMessage<KnockKnockResponse> {
    private static readonly pb::MessageParser<KnockKnockResponse> _parser = new pb::MessageParser<KnockKnockResponse>(() => new KnockKnockResponse());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<KnockKnockResponse> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::KnockKnock.KnockKnockReflection.Descriptor.MessageTypes[1]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public KnockKnockResponse() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public KnockKnockResponse(KnockKnockResponse other) : this() {
      line_ = other.line_;
      isPunchLine_ = other.isPunchLine_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public KnockKnockResponse Clone() {
      return new KnockKnockResponse(this);
    }

    /// <summary>Field number for the "line" field.</summary>
    public const int LineFieldNumber = 1;
    private string line_ = "";
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public string Line {
      get { return line_; }
      set {
        line_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    /// <summary>Field number for the "isPunchLine" field.</summary>
    public const int IsPunchLineFieldNumber = 2;
    private bool isPunchLine_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool IsPunchLine {
      get { return isPunchLine_; }
      set {
        isPunchLine_ = value;
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as KnockKnockResponse);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(KnockKnockResponse other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (Line != other.Line) return false;
      if (IsPunchLine != other.IsPunchLine) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (Line.Length != 0) hash ^= Line.GetHashCode();
      if (IsPunchLine != false) hash ^= IsPunchLine.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (Line.Length != 0) {
        output.WriteRawTag(10);
        output.WriteString(Line);
      }
      if (IsPunchLine != false) {
        output.WriteRawTag(16);
        output.WriteBool(IsPunchLine);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (Line.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeStringSize(Line);
      }
      if (IsPunchLine != false) {
        size += 1 + 1;
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(KnockKnockResponse other) {
      if (other == null) {
        return;
      }
      if (other.Line.Length != 0) {
        Line = other.Line;
      }
      if (other.IsPunchLine != false) {
        IsPunchLine = other.IsPunchLine;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 10: {
            Line = input.ReadString();
            break;
          }
          case 16: {
            IsPunchLine = input.ReadBool();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code

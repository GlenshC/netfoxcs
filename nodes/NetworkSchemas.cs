using Godot;

namespace Netfox;

public class NetworkSchemas
{
	private static Script _script = GD.Load<Script>("res://addons/netfox/schemas/network-schemas.gd");

	/// <summary>
    /// Serialize any data type supported by @GlobalScope.var_to_bytes().
    /// Final size depends on the value.
    /// </summary>
    public static Variant Variant()
    {
        return _script.Call(MethodNameGd.Variant);
    }

    /// <summary>
    /// Serialize strings in UTF-8 encoding.
    /// Final size depends on the string, the string itself is zero-terminated. Data is prepended by a 32-bit integer representing the string's size. Faster than c_string(), at the cost of using 4 more bytes.
    /// </summary>
    public static Variant String()
    {
        return _script.Call(MethodNameGd.String);
    }

    /// <summary>
    /// Serialize strings in UTF-8 encoding, terminated with a null byte.
    /// Final size depends on the string, the string itself is zero-terminated. Contrary to string(), the length of the string is not included. Slightly slower than string(), but uses less data.
    /// </summary>
    public static Variant CString()
    {
        return _script.Call(MethodNameGd.CString);
    }

    /// <summary>
    /// Serialize booleans as 8 bits.
    /// Final size is 1 byte.
    /// </summary>
    public static Variant Bool8()
    {
        return _script.Call(MethodNameGd.Bool8);
    }

    /// <summary>
    /// Serialize unsigned integers as 8 bits.
    /// Final size is 1 byte.
    /// </summary>
    public static Variant Uint8()
    {
        return _script.Call(MethodNameGd.Uint8);
    }

    /// <summary>
    /// Serialize unsigned integers as 16 bits.
    /// Final size is 2 bytes.
    /// </summary>
    public static Variant Uint16()
    {
        return _script.Call(MethodNameGd.Uint16);
    }

    /// <summary>
    /// Serialize unsigned integers as 32 bits.
    /// Final size is 4 bytes.
    /// </summary>
    public static Variant Uint32()
    {
        return _script.Call(MethodNameGd.Uint32);
    }

    /// <summary>
    /// Serialize unsigned integers as 64 bits.
    /// Final size is 8 bytes.
    /// </summary>
    public static Variant Uint64()
    {
        return _script.Call(MethodNameGd.Uint64);
    }

    /// <summary>
    /// Serialize an unsigned integer as a variable amount of bytes.
    /// Each byte contains 7 bits of data. The 8th bit indicates whether there are more bytes left. Thus, small numbers fitting into 7 bits will be encoded as a single byte, while larger numbers take more space as they increase.
    /// Final size is 1 byte for every 7 bits of numeric data.
    /// </summary>
    public static Variant Varuint()
    {
        return _script.Call(MethodNameGd.Varuint);
    }

    /// <summary>
    /// Serialize signed integers as 8 bits.
    /// Final size is 1 byte.
    /// </summary>
    public static Variant Int8()
    {
        return _script.Call(MethodNameGd.Int8);
    }

    /// <summary>
    /// Serialize signed integers as 16 bits.
    /// Final size is 2 bytes.
    /// </summary>
    public static Variant Int16()
    {
        return _script.Call(MethodNameGd.Int16);
    }

    /// <summary>
    /// Serialize signed integers as 32 bits.
    /// Final size is 4 bytes.
    /// </summary>
    public static Variant Int32()
    {
        return _script.Call(MethodNameGd.Int32);
    }

    /// <summary>
    /// Serialize signed integers as 64 bits.
    /// Final size is 8 bytes.
    /// </summary>
    public static Variant Int64()
    {
        return _script.Call(MethodNameGd.Int64);
    }

    /// <summary>
    /// Serialize floats in half-precision, as 16 bits.
    /// This is only supported in Godot 4.4 and up, earlier versions fall back to float32().
    /// Final size is 2 bytes, 4 if using fallback.
    /// </summary>
    public static Variant Float16()
    {
        return _script.Call(MethodNameGd.Float16);
    }

    /// <summary>
    /// Serialize floats in single-precision, as 32 bits.
    /// Final size is 4 bytes.
    /// </summary>
    public static Variant Float32()
    {
        return _script.Call(MethodNameGd.Float32);
    }

    /// <summary>
    /// Serialize floats in double-precision, as 64 bits.
    /// Final size is 8 bytes.
    /// </summary>
    public static Variant Float64()
    {
        return _script.Call(MethodNameGd.Float64);
    }

    /// <summary>
    /// Serialize signed fractions in the [-1.0, +1.0] range as 8 bits.
    /// Final size is 1 byte.
    /// </summary>
    public static Variant SFrac8()
    {
        return _script.Call(MethodNameGd.SFrac8);
    }

    /// <summary>
    /// Serialize signed fractions in the [-1.0, +1.0] range as 16 bits.
    /// Final size is 2 bytes.
    /// </summary>
    public static Variant SFrac16()
    {
        return _script.Call(MethodNameGd.SFrac16);
    }

    /// <summary>
    /// Serialize signed fractions in the [-1.0, +1.0] range as 32 bits.
    /// Final size is 4 bytes.
    /// </summary>
    public static Variant SFrac32()
    {
        return _script.Call(MethodNameGd.SFrac32);
    }

    /// <summary>
    /// Serialize signed fractions in the [0.0, 1.0] range as 8 bits.
    /// Final size is 1 byte.
    /// </summary>
    public static Variant UFrac8()
    {
        return _script.Call(MethodNameGd.UFrac8);
    }

    /// <summary>
    /// Serialize signed fractions in the [0.0, 1.0] range as 16 bits.
    /// Final size is 2 bytes.
    /// </summary>
    public static Variant UFrac16()
    {
        return _script.Call(MethodNameGd.UFrac16);
    }

    /// <summary>
    /// Serialize signed fractions in the [0.0, 1.0] range as 32 bits.
    /// Final size is 4 bytes.
    /// </summary>
    public static Variant UFrac32()
    {
        return _script.Call(MethodNameGd.UFrac32);
    }

    /// <summary>
    /// Serialize degrees as 8 bits. The value will always decode to the [0.0, 360.0) range.
    /// Final size is 1 byte.
    /// </summary>
    public static Variant Degrees8()
    {
        return _script.Call(MethodNameGd.Degrees8);
    }

    /// <summary>
    /// Serialize degrees as 16 bits. The value will always decode to the [0.0, 360.0) range.
    /// Final size is 2 bytes.
    /// </summary>
    public static Variant Degrees16()
    {
        return _script.Call(MethodNameGd.Degrees16);
    }

    /// <summary>
    /// Serialize degrees as 32 bits. The value will always decode to the [0.0, 360.0) range.
    /// Final size is 4 bytes.
    /// </summary>
    public static Variant Degrees32()
    {
        return _script.Call(MethodNameGd.Degrees32);
    }

    /// <summary>
    /// Serialize radians as 8 bits. The value will always decode to the [0.0, TAU) range.
    /// Final size is 1 byte.
    /// </summary>
    public static Variant Radians8()
    {
        return _script.Call(MethodNameGd.Radians8);
    }

    /// <summary>
    /// Serialize radians as 16 bits. The value will always decode to the [0.0, TAU) range.
    /// Final size is 2 bytes.
    /// </summary>
    public static Variant Radians16()
    {
        return _script.Call(MethodNameGd.Radians16);
    }

    /// <summary>
    /// Serialize radians as 32 bits. The value will always decode to the [0.0, TAU) range.
    /// Final size is 4 bytes.
    /// </summary>
    public static Variant Radians32()
    {
        return _script.Call(MethodNameGd.Radians32);
    }

    /// <summary>
    /// Serialize Vector2 objects, using component_serializer to serialize each component of the vector.
    /// Serializes 2 components, size depends on the component_serializer.
    /// </summary>
    public static Variant Vec2T(Variant componentSerializer)
    {
        return _script.Call(MethodNameGd.Vec2T, componentSerializer);
    }

    /// <summary>
    /// Serialize Vector2 objects, with each component being a half-precision float.
    /// This is only supported in Godot 4.4 and up. Earlier versions fall back to vec2f32().
    /// Final size is 4 bytes, 8 if using fallback.
    /// </summary>
    public static Variant Vec2F16()
    {
        return _script.Call(MethodNameGd.Vec2F16);
    }

    /// <summary>
    /// Serialize Vector2 objects, with each component being a single-precision float.
    /// Final size is 8 bytes.
    /// </summary>
    public static Variant Vec2F32()
    {
        return _script.Call(MethodNameGd.Vec2F32);
    }

    /// <summary>
    /// Serialize Vector2 objects, with each component being a double-precision float.
    /// Final size is 16 bytes.
    /// </summary>
    public static Variant Vec2F64()
    {
        return _script.Call(MethodNameGd.Vec2F64);
    }

    /// <summary>
    /// Serialize Vector3 objects, using component_serializer to serialize each component of the vector.
    /// Serializes 3 components, size depends on the component_serializer.
    /// </summary>
    public static Variant Vec3T(Variant componentSerializer)
    {
        return _script.Call(MethodNameGd.Vec3T, componentSerializer);
    }

    /// <summary>
    /// Serialize Vector3 objects, with each component being a half-precision float.
    /// This is only supported in Godot 4.4 and up. Earlier versions fall back to vec3f32().
    /// Final size is 6 bytes, 12 if using fallback.
    /// </summary>
    public static Variant Vec3F16()
    {
        return _script.Call(MethodNameGd.Vec3F16);
    }

    /// <summary>
    /// Serialize Vector3 objects, with each component being a double-precision float.
    /// Final size is 12 bytes.
    /// </summary>
    public static Variant Vec3F32()
    {
        return _script.Call(MethodNameGd.Vec3F32);
    }

    /// <summary>
    /// Serialize Vector3 objects, with each component being a double-precision float.
    /// Final size is 24 bytes.
    /// </summary>
    public static Variant Vec3F64()
    {
        return _script.Call(MethodNameGd.Vec3F64);
    }

    /// <summary>
    /// Serialize Vector4 objects, using component_serializer to serialize each component of the vector.
    /// Serializes 4 components, size depends on the component_serializer.
    /// </summary>
    public static Variant Vec4T(Variant componentSerializer)
    {
        return _script.Call(MethodNameGd.Vec4T, componentSerializer);
    }

    /// <summary>
    /// Serialize Vector4 objects, with each component being a half-precision float.
    /// This is only supported in Godot 4.4 and up. Earlier versions fall back to vec4f32().
    /// Final size is 8 bytes, 16 if using fallback.
    /// </summary>
    public static Variant Vec4F16()
    {
        return _script.Call(MethodNameGd.Vec4F16);
    }

    /// <summary>
    /// Serialize Vector4 objects, with each component being a double-precision float.
    /// Final size is 16 bytes.
    /// </summary>
    public static Variant Vec4F32()
    {
        return _script.Call(MethodNameGd.Vec4F32);
    }

    /// <summary>
    /// Serialize Vector4 objects, with each component being a double-precision float.
    /// Final size is 32 bytes.
    /// </summary>
    public static Variant Vec4F64()
    {
        return _script.Call(MethodNameGd.Vec4F64);
    }

    /// <summary>
    /// Serialize normalized Vector2 objects, using component_serializer to serialize each component of the vector.
    /// Serializes 1 component, size depends on the component_serializer.
    /// </summary>
    public static Variant Normal2T(Variant componentSerializer)
    {
        return _script.Call(MethodNameGd.Normal2T, componentSerializer);
    }

    /// <summary>
    /// Serialize normalized Vector2 objects, with each component being a half-precision float.
    /// This is only supported in Godot 4.4 and up. Earlier versions fall back to normal2f32().
    /// Final size is 2 bytes, 4 if using fallback.
    /// </summary>
    public static Variant Normal2F16()
    {
        return _script.Call(MethodNameGd.Normal2F16);
    }

    /// <summary>
    /// Serialize normalized Vector2 objects, with each component being a single-precision float.
    /// Final size is 4 bytes.
    /// </summary>
    public static Variant Normal2F32()
    {
        return _script.Call(MethodNameGd.Normal2F32);
    }

    /// <summary>
    /// Serialize normalized Vector2 objects, with each component being a double-precision float.
    /// Final size is 8 bytes.
    /// </summary>
    public static Variant Normal2F64()
    {
        return _script.Call(MethodNameGd.Normal2F64);
    }

    /// <summary>
    /// Serialize normalized Vector3 objects, using component_serializer to serialize each component of the vector.
    /// Serializes 2 components, size depends on the component_serializer.
    /// </summary>
    public static Variant Normal3T(Variant componentSerializer)
    {
        return _script.Call(MethodNameGd.Normal3T, componentSerializer);
    }

    /// <summary>
    /// Serialize normalized Vector3 objects, with each component being a half-precision float.
    /// This is only supported in Godot 4.4 and up. Earlier versions fall back to normal3f32().
    /// Final size is 4 bytes, 8 if using fallback.
    /// </summary>
    public static Variant Normal3F16()
    {
        return _script.Call(MethodNameGd.Normal3F16);
    }

    /// <summary>
    /// Serialize normalized Vector3 objects, with each component being a single-precision float.
    /// Final size is 8 bytes.
    /// </summary>
    public static Variant Normal3F32()
    {
        return _script.Call(MethodNameGd.Normal3F32);
    }

    /// <summary>
    /// Serialize normalized Vector3 objects, with each component being a double-precision float.
    /// Final size is 16 bytes.
    /// </summary>
    public static Variant Normal3F64()
    {
        return _script.Call(MethodNameGd.Normal3F64);
    }

    /// <summary>
    /// Serialize Quaternion objects, using component_serializer to serialize each component of the quaternion.
    /// Serializes 4 components, size depends on the component_serializer.
    /// </summary>
    public static Variant QuatT(Variant componentSerializer)
    {
        return _script.Call(MethodNameGd.QuatT, componentSerializer);
    }

    /// <summary>
    /// Serialize Quaternion objects, with each component being a half-precision float.
    /// This is only supported in Godot 4.4 and up. Earlier versions fall back to quat32f().
    /// Final size is 8 bytes, 16 if using fallback.
    /// </summary>
    public static Variant QuatF16()
    {
        return _script.Call(MethodNameGd.QuatF16);
    }

    /// <summary>
    /// Serialize Quaternion objects, with each component being a single-precision float.
    /// Final size is 16 bytes.
    /// </summary>
    public static Variant QuatF32()
    {
        return _script.Call(MethodNameGd.QuatF32);
    }

    /// <summary>
    /// Serialize Quaternion objects, with each component being a double-precision float.
    /// Final size is 32 bytes.
    /// </summary>
    public static Variant QuatF64()
    {
        return _script.Call(MethodNameGd.QuatF64);
    }

    /// <summary>
    /// Serialize Transform2D objects, using component_serializer to serialize each component of the transform.
    /// Serializes a 2x3 matrix in 6 components, final size depends on component_serializer.
    /// </summary>
    public static Variant Transform2T(Variant componentSerializer)
    {
        return _script.Call(MethodNameGd.Transform2T, componentSerializer);
    }

    /// <summary>
    /// Serialize Transform2D objects, with each component being a half-precision float.
    /// This is only supported in Godot 4.4 and up. Earlier versions fall back to transform2f32().
    /// Final size is 12 bytes, 24 if using fallback.
    /// </summary>
    public static Variant Transform2F16()
    {
        return _script.Call(MethodNameGd.Transform2F16);
    }

    /// <summary>
    /// Serialize Transform2D objects, with each component being a single-precision float.
    /// Final size is 24 bytes.
    /// </summary>
    public static Variant Transform2F32()
    {
        return _script.Call(MethodNameGd.Transform2F32);
    }

    /// <summary>
    /// Serialize Transform2D objects, with each component being a double-precision float.
    /// Final size is 48 bytes.
    /// </summary>
    public static Variant Transform2F64()
    {
        return _script.Call(MethodNameGd.Transform2F64);
    }

    /// <summary>
    /// Serialize Transform3D objects, using component_serializer to serialize each component of the transform.
    /// Serializes a 3x4 matrix in 12 components, final size depends on component_serializer.
    /// </summary>
    public static Variant Transform3T(Variant componentSerializer)
    {
        return _script.Call(MethodNameGd.Transform3T, componentSerializer);
    }

    /// <summary>
    /// Serialize Transform3D objects, with each component being a half-precision float.
    /// This is only supported in Godot 4.4 and up. Earlier versions fall back to transform3f32().
    /// Final size is 24 bytes, 48 if using fallback.
    /// </summary>
    public static Variant Transform3F16()
    {
        return _script.Call(MethodNameGd.Transform3F16);
    }

    /// <summary>
    /// Serialize Transform3D objects, with each component being a single-precision float.
    /// Final size is 48 bytes.
    /// </summary>
    public static Variant Transform3F32()
    {
        return _script.Call(MethodNameGd.Transform3F32);
    }

    /// <summary>
    /// Serialize Transform2D objects, with each component being a double-precision float.
    /// Final size is 96 bytes.
    /// </summary>
    public static Variant Transform3F64()
    {
        return _script.Call(MethodNameGd.Transform3F64);
    }

    /// <summary>
    /// Serialize homogenoeous arrays, using item_serializer to serialize each item, and size_serializer to serialize the array's size.
    /// To serialize heterogenoeous arrays, use variant() as the item serializer.
    /// Final size is sizeof(size_serializer) + array.size() * sizeof(item_serializer)
    /// </summary>
    public static Variant ArrayOf(Variant itemSerializer, Variant sizeSerializer)
    {
        return _script.Call(MethodNameGd.ArrayOf, itemSerializer, sizeSerializer);
    }

    /// <summary>
    /// Serialize homogenoeous dictionaries, using key_serialize and value_serializer to serialize key-value pairs, and size_serializer to serialize the number of entries.
    /// If either the keys or values are not homogenoeous, use variant().
    /// Final size is sizeof(size_serializer) + dictionary.size() * (sizeof(key_serializer) + sizeof(value_serializer))
    /// </summary>
    public static Variant Dictionary(Variant keySerializer, Variant valueSerializer, Variant sizeSerializer)
    {
        return _script.Call(MethodNameGd.Dictionary, keySerializer, valueSerializer, sizeSerializer);
    }

    static class MethodNameGd
    {
        public static readonly StringName Variant = "variant";
        public static readonly StringName String = "string";
        public static readonly StringName CString = "c_string";
        public static readonly StringName Bool8 = "bool8";
        public static readonly StringName Uint8 = "uint8";
        public static readonly StringName Uint16 = "uint16";
        public static readonly StringName Uint32 = "uint32";
        public static readonly StringName Uint64 = "uint64";
        public static readonly StringName Varuint = "varuint";
        public static readonly StringName Int8 = "int8";
        public static readonly StringName Int16 = "int16";
        public static readonly StringName Int32 = "int32";
        public static readonly StringName Int64 = "int64";
        public static readonly StringName Float16 = "float16";
        public static readonly StringName Float32 = "float32";
        public static readonly StringName Float64 = "float64";
        public static readonly StringName SFrac8 = "sfrac8";
        public static readonly StringName SFrac16 = "sfrac16";
        public static readonly StringName SFrac32 = "sfrac32";
        public static readonly StringName UFrac8 = "ufrac8";
        public static readonly StringName UFrac16 = "ufrac16";
        public static readonly StringName UFrac32 = "ufrac32";
        public static readonly StringName Degrees8 = "degrees8";
        public static readonly StringName Degrees16 = "degrees16";
        public static readonly StringName Degrees32 = "degrees32";
        public static readonly StringName Radians8 = "radians8";
        public static readonly StringName Radians16 = "radians16";
        public static readonly StringName Radians32 = "radians32";
        public static readonly StringName Vec2T = "vec2t";
        public static readonly StringName Vec2F16 = "vec2f16";
        public static readonly StringName Vec2F32 = "vec2f32";
        public static readonly StringName Vec2F64 = "vec2f64";
        public static readonly StringName Vec3T = "vec3t";
        public static readonly StringName Vec3F16 = "vec3f16";
        public static readonly StringName Vec3F32 = "vec3f32";
        public static readonly StringName Vec3F64 = "vec3f64";
        public static readonly StringName Vec4T = "vec4t";
        public static readonly StringName Vec4F16 = "vec4f16";
        public static readonly StringName Vec4F32 = "vec4f32";
        public static readonly StringName Vec4F64 = "vec4f64";
        public static readonly StringName Normal2T = "normal2t";
        public static readonly StringName Normal2F16 = "normal2f16";
        public static readonly StringName Normal2F32 = "normal2f32";
        public static readonly StringName Normal2F64 = "normal2f64";
        public static readonly StringName Normal3T = "normal3t";
        public static readonly StringName Normal3F16 = "normal3f16";
        public static readonly StringName Normal3F32 = "normal3f32";
        public static readonly StringName Normal3F64 = "normal3f64";
        public static readonly StringName QuatT = "quatt";
        public static readonly StringName QuatF16 = "quatf16";
        public static readonly StringName QuatF32 = "quatf32";
        public static readonly StringName QuatF64 = "quatf64";
        public static readonly StringName Transform2T = "transform2t";
        public static readonly StringName Transform2F16 = "transform2f16";
        public static readonly StringName Transform2F32 = "transform2f32";
        public static readonly StringName Transform2F64 = "transform2f64";
        public static readonly StringName Transform3T = "transform3t";
        public static readonly StringName Transform3F16 = "transform3f16";
        public static readonly StringName Transform3F32 = "transform3f32";
        public static readonly StringName Transform3F64 = "transform3f64";
        public static readonly StringName ArrayOf = "array_of";
        public static readonly StringName Dictionary = "dictionary";
    }

}

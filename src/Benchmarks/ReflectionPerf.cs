﻿using BenchmarkComponent;
using BenchmarkDotNet.Attributes;
using System;

namespace Benchmarks
{
    [MemoryDiagnoser]
    public class ReflectionPerf
    {
        ClassWithMarshalingRoutines instance;

        [GlobalSetup]
        public void Setup()
        {
            instance = new ClassWithMarshalingRoutines();
        }

        [Benchmark]
        public object ExecuteMarshalingForNewKeyValuePair()
        {
            return instance.NewTypeErasedKeyValuePairObject;
        }

        [Benchmark]
        public object ExecuteMarshalingForNewArray()
        {
            return instance.NewTypeErasedArrayObject;
        }

        [Benchmark]
        public object ExecuteMarshalingForNewNullable()
        {
            return instance.NewTypeErasedNullableObject;
        }

        [Benchmark]
        public object ExecuteMarshalingForExistingKeyvaluePair()
        {
            return instance.ExistingTypeErasedKeyValuePairObject;
        }

        [Benchmark]
        public object ExecuteMarshalingForExistingArray()
        {
            return instance.ExistingTypeErasedArrayObject;
        }

        [Benchmark]
        public object ExecuteMarshalingForExistingNullable()
        {
            return instance.ExistingTypeErasedNullableObject;
        }

        [Benchmark]
        public object ExecuteMarshalingForString()
        {
            return instance.DefaultStringProperty;
        }

        [Benchmark]
        public object ExecuteMarshalingForCustomObject()
        {
            return instance.NewWrappedClassObject;
        }

        [Benchmark]
        public void IntEventSource()
        {
            ClassWithMarshalingRoutines instance = new ClassWithMarshalingRoutines();

            int x = 0;
            int y = 1;
            int z;

            instance.IntProperty = x;
            instance.CallForInt(() => y);

            instance.IntPropertyChanged += (object sender, int value) => z = value;
            instance.RaiseIntChanged();
        }
    }
}

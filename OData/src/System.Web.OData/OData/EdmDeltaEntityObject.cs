﻿// Copyright (c) Microsoft Corporation.  All rights reserved.
// Licensed under the MIT License.  See License.txt in the project root for license information.

using System.Diagnostics.Contracts;
using Microsoft.OData.Edm;

namespace System.Web.OData
{
    /// <summary>
    /// Represents an <see cref="IEdmChangedObject"/> with no backing CLR <see cref="Type"/>.
    /// Used to hold the Entry object in the Delta Feed Payload.
    /// </summary>
    public class EdmDeltaEntityObject : EdmEntityObject, IEdmChangedObject
    {
        private EdmDeltaType _edmType;

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmDeltaEntityObject"/> class.
        /// </summary>
        /// <param name="entityType">The <see cref="IEdmEntityType"/> of this DeltaEntityObject.</param>
        public EdmDeltaEntityObject(IEdmEntityType entityType)
            : this(entityType, isNullable: false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmDeltaEntityObject"/> class.
        /// </summary>
        /// <param name="entityTypeReference">The <see cref="IEdmEntityTypeReference"/> of this DeltaEntityObject.</param>
        public EdmDeltaEntityObject(IEdmEntityTypeReference entityTypeReference)
            : this(entityTypeReference.EntityDefinition(), entityTypeReference.IsNullable)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EdmDeltaEntityObject"/> class.
        /// </summary>
        /// <param name="entityType">The <see cref="IEdmEntityType"/> of this DeltaEntityObject.</param>
        /// <param name="isNullable">true if this object can be nullable; otherwise, false.</param>
        public EdmDeltaEntityObject(IEdmEntityType entityType, bool isNullable)
            : base(entityType, isNullable)
        {
            _edmType = new EdmDeltaType(entityType, EdmDeltaEntityKind.Entry);
        }

        /// <inheritdoc />
        public EdmDeltaEntityKind DeltaKind
        {
            get
            {
                Contract.Assert(_edmType != null);
                return _edmType.DeltaKind;
            }
        }
    }
}
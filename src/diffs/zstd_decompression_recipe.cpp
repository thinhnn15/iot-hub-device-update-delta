/**
 * @file zstd_decompression_recipe.cpp
 *
 * @copyright Copyright (c) Microsoft Corporation.
 * Licensed under the MIT License.
 */
#include "zstd_decompression_recipe.h"

#include "archive_item.h"

#include "zstd_decompression_reader.h"

void diffs::zstd_decompression_recipe::apply(apply_context &context) const
{
	auto reader = make_reader(context);
	context.write_target(reader.get());
}

std::unique_ptr<io_utility::reader> diffs::zstd_decompression_recipe::make_reader(apply_context &context) const
{
	verify_parameter_count(1);

	auto item = m_parameters[0].get_archive_item_value();

	auto reader = std::make_unique<io_utility::zstd_decompression_reader>(
		std::move(item->make_reader(context)), m_blobdef.m_length);

	return reader;
}
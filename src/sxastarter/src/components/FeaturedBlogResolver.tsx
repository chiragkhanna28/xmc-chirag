import React from 'react';
import {
  RichText as JssRichText,
  Field,
  Text,
  Link as JssLink,
  LinkField,
  Image as JssImage,
  ImageField,
} from '@sitecore-jss/sitecore-jss-nextjs';

type FeaturedBlog = {
  Title: Field<string>;
  Description: Field<string>;
  Link: LinkField;
  Image: ImageField;
};

type FeaturedBlogFields = {
  fields: FeaturedBlog;
};

type PromoProps = {
  fields: {
    Heading: Field<string>;
    items: FeaturedBlogFields[];
  };
};

export const Default = (props: PromoProps): JSX.Element => {
  console.log('Resolver Json');
  console.log(props);

  return (
    <div className="row component">
      <h1>
        <Text className="" field={props.fields.Heading} />
      </h1>
      {props.fields.items.map((item) => {
        return (
          <div className="col-4" key={item.fields.Title.value}>
            <Text className="promo-text" field={item.fields.Title} />
            <JssRichText field={item.fields.Description} />
            <JssLink field={item.fields.Link} />
            <JssImage field={item.fields.Image} />
          </div>
        );
      })}
    </div>
  );
};

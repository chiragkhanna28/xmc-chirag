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
  params: { [key: string]: string };
  fields: {
    Heading: Field<string>;
    items: FeaturedBlogFields[];
  };
};

const FeaturedBlogResolverDefaultComponent = (props: PromoProps): JSX.Element => (
  <div className={`component promo ${props.params.styles}`}>
    <div className="component-content">
      <span className="is-empty-hint">Featured Blog Resolver</span>
    </div>
  </div>
);

export const Default = (props: PromoProps): JSX.Element => {
  console.log('Resolver Json');
  console.log(props);
  if (props.fields) {
    return (
      <div className="row component testing">
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
  }
  return <FeaturedBlogResolverDefaultComponent {...props} />;
};

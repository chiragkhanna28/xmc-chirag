import React from 'react';
import {
  RichText as JssRichText,
  Field,
  Text,
  Image as JssImage,
  ImageField,
} from '@sitecore-jss/sitecore-jss-nextjs';

type BlogLink = {
  text: string;
  url: string;
};

type BlogImageField = {
  jsonValue: ImageField;
};

type FeaturedBlog = {
  name: string;
  title: Field<string>;
  description: Field<string>;
  link: BlogLink;
  image: BlogImageField;
};

type PromoProps = {
  fields: {
    data: {
      item: {
        heading: Field<string>;
        featuredblogs: {
          blogs: FeaturedBlog[];
        };
      };
    };
  };
};

export const Default = (props: PromoProps): JSX.Element => {
  console.log('GraphQL Json');
  console.log(props);

  return (
    <div className="row component">
      <h1>
        <Text className="" field={props.fields.data.item.heading} />
      </h1>
      {props.fields.data.item.featuredblogs.blogs.map((item) => {
        return (
          <div className="col-4" key={item.title.value}>
            <Text className="promo-text" field={item.title} />
            <JssRichText field={item.description} />
            <a href={`/${item.link.url}`}>{item.link.text}</a>
            <JssImage field={item.image.jsonValue} />
          </div>
        );
      })}
    </div>
  );
};
